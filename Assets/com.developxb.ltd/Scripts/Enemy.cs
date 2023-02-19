using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float offsetX = 0.8f;
    private const float speed = 1.2f;

    private float nextTime;
    private const float waitTime = 2.0f;

    private SpriteRenderer Render { get; set; }

    private Vector2 target;

    private void Awake()
    {
        target = new Vector2(0, transform.position.y);
        Render = GetComponent<SpriteRenderer>();

        nextTime = waitTime;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
            target = new Vector2(Random.Range(-offsetX, offsetX), transform.position.y);
        }
    }

    private void Update()
    {
        if(Time.time > nextTime)
        {
            Render.enabled = false;
            nextTime = Time.time + waitTime;

            Rigidbody2D ball = Instantiate(Resources.Load<Rigidbody2D>("ball"), transform.parent);
            ball.position = transform.position;

            Vector2 direction = (new Vector2(Random.Range(-0.8f, 0.8f), 3.0f) - (Vector2)transform.position).normalized;
            ball.AddForce(direction * 10, ForceMode2D.Impulse);

            Destroy(ball.gameObject, 4.0f);
            Invoke(nameof(EnableRender), 4.0f);
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void EnableRender()
    {
        Render.enabled = true;
    }
}
