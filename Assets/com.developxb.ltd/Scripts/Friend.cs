using System;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public static Action OnCollided { get; set; }

    private void OnMouseDrag()
    {
        if(GameManager.IsPaused)
        {
            return;
        }

        transform.localPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.localPosition.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.position.y < transform.position.y)
        {
            OnCollided?.Invoke();
        }
    }
}