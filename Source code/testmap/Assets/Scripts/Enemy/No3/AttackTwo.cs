using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTwo : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer;

    public GameObject attackForward;
    public GameObject attackAfter;
    public GameObject attackEffect;

    private EnemyAI ai;
    private Vector2 movement;
    private bool isAttack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cooldownTimer = Mathf.Infinity;
        ai = GetComponent<EnemyAI>();
        movement = ai.GetMovement();
        isAttack = ai.GetAttackRange();
    }

    private void Update()
    {
        isAttack = ai.GetAttackRange();
        movement = ai.GetMovement();
        if (isAttack)
        {
            if ((movement.x > 0 && movement.y > 0) || (movement.x > 0 && movement.y < 0))
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
            Attacking();
        }
    }

    public void Attacking()
    {
        rb.velocity = Vector2.zero;
        if (cooldownTimer > attackCooldown)
        {
            if (movement.y > 0)
            {
                attackEffect.transform.localScale = new Vector2(1, 1);
                Instantiate(attackEffect, attackAfter.transform.position, attackAfter.transform.rotation, attackAfter.transform);
            }
            if (movement.y < 0)
            {
                attackEffect.transform.localScale = new Vector2(1, -1);
                Instantiate(attackEffect, attackForward.transform.position, attackForward.transform.rotation, attackForward.transform);
            }
            cooldownTimer = 0;
        }
        cooldownTimer += Time.deltaTime;
    }
}
