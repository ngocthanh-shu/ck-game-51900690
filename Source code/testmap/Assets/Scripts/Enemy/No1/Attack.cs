using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer;

    public GameObject attackForward;
    public GameObject attackAfter;
    public GameObject attackEffect;
    private EnemyAI ai;
    private bool isAttack;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cooldownTimer = Mathf.Infinity;
        ai = GetComponent<EnemyAI>();
        isAttack = ai.GetAttackRange();
        movement = ai.GetMovement();
    }

    private void Update()
    {
        movement = ai.GetMovement();
        isAttack = ai.GetAttackRange();
        if (isAttack)
        {
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
                attackEffect.transform.localScale = new Vector2(-1, attackEffect.transform.localScale.y);
                Instantiate(attackEffect, attackAfter.transform.position, attackAfter.transform.rotation, attackAfter.transform);
            }
            if (movement.y < 0)
            {
                attackEffect.transform.localScale = new Vector2(1, attackEffect.transform.localScale.y);
                Instantiate(attackEffect, attackForward.transform.position, attackForward.transform.rotation, attackForward.transform);
            }
            cooldownTimer = 0;
        }
        cooldownTimer += Time.deltaTime;
    }
}
