using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private float speed;

    [SerializeField] bool IsEnemy;
    public static Action<bool> OnBallPressed { get; set; }

    private void Start()
    {
        speed = Random.Range(3.5f, 8.0f);

        float x = Random.Range(0, 100) > 50 ? -5.0f : 5.0f;
        float y = Random.Range(0, 100) > 50 ? -10.0f : 10.0f;

        transform.localPosition = new Vector2(x, y);
        transform.up = (Vector2.zero - (Vector2)transform.position).normalized;

        Destroy(gameObject, 10.0f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    private void OnMouseDown()
    {
        OnBallPressed?.Invoke(IsEnemy);
        Destroy(gameObject);
    }
}
