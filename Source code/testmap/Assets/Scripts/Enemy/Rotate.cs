using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private EnemyAI ai;
    private bool isInChaseRange;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<EnemyAI>();
        isInChaseRange = ai.GetChaseRange();
        rb = GetComponent<Rigidbody2D>();
        movement = ai.GetMovement();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isInChaseRange = ai.GetChaseRange();
        movement = ai.GetMovement();
        RotateCharacter(movement);
    }

    public void RotateCharacter(Vector2 dir)
    {
        if (isInChaseRange)
        {
            if ((dir.x < 0 && dir.y > 0) || (dir.x > 0 && dir.y < 0))
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else if (dir.y > 0)
        {
            anim.SetBool("after", true);
        }
        else
        {
            anim.SetBool("after", false);
        }
    }
}
