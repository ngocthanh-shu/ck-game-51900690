using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private Transform target;
    public Vector3 dir;
    private Vector2 movement;

    private void Start()
    {
        speed = 35;
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        dir = target.position - transform.position;
        dir.Normalize();
        movement = dir;
        if (dir.x > 0)
        {
            if (dir.y > 0)
                transform.localScale = new Vector2(-1, 1);
            else
                transform.localScale = new Vector2(-1, -1);
        }
        else
        {
            if (dir.y > 0)
                transform.localScale = new Vector2(1, 1);
            else
                transform.localScale = new Vector2(1, -1);
        }
    }

    void Update()
    {
        rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
        
    }
}
