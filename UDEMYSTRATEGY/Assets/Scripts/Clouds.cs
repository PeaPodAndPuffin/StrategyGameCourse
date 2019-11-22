using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float speed;

    public float maxX;
    public float minX;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > maxX) {
            transform.position = new Vector2(minX, transform.position.y);
        } 
    }

}
