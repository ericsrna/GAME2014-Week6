using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BulletDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
}

[System.Serializable]
public struct ScreenBounds
{
    public Boundary horizontal;
    public Boundary vertical;
}

public class BulletBehaviour : MonoBehaviour
{
    public BulletDirection direction;
    public float speed;
    public Vector3 velocity;
    public ScreenBounds bounds;

    void Start()
    {
        switch(direction)
        {
            case BulletDirection.UP:
                velocity = Vector3.up * speed * Time.deltaTime;
                break;
            case BulletDirection.DOWN:
                velocity = Vector3.down * speed * Time.deltaTime;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left * speed * Time.deltaTime;
                break;
            case BulletDirection.RIGHT:
                velocity = Vector3.right * speed * Time.deltaTime;
                break;
        }
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        transform.position += velocity;
    }

    void CheckBounds()
    {
        if ((transform.position.x > bounds.horizontal.max) || 
            (transform.position.x < bounds.horizontal.min) ||
            (transform.position.y > bounds.vertical.max) ||
            (transform.position.y < bounds.vertical.min)
            )
        {
            // return the bullet to the pool
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
