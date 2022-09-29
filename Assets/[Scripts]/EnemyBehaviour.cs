using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundary horizontalBoundary;
    public Boundary verticalBoundary;
    public float horizontalSpeed;

    void Start()
    {
        var startingXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
        var startingYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
        transform.position = new Vector3(startingXPosition, startingYPosition, 0.0f);
        horizontalSpeed = Random.Range(1.0f, 6.0f);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        var boundaryLength = horizontalBoundary.max - horizontalBoundary.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, boundaryLength) - horizontalBoundary.max, 
            transform.position.y, 0.0f);
    }
}
