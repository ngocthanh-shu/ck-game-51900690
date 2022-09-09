using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGen2 : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer;

    public GameObject attack;
    public GameObject attackEffect;
    private EnemyAIGen2 ai;
    private bool isAttack;
    private bool isChase;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldownTimer = Mathf.Infinity;
        anim = GetComponent<Animator>();
        ai = GetComponent<EnemyAIGen2>();
        isAttack = ai.GetAttackRange();
        isChase = ai.GetChaseRange();

    }

    private void Update()
    {
        isAttack = ai.GetAttackRange();
        if (isAttack)
        {
            Attacking();
        }
        if (ai.GetMovement().x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
        cooldownTimer += Time.deltaTime;

    }

    public void Attacking()
    {
        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            if (cooldownTimer > attackCooldown)
            {
                anim.SetBool("isAttack", true);
                attackEffect.transform.localScale = new Vector2(transform.localScale.x*Mathf.Abs(attackEffect.transform.localScale.x), attackEffect.transform.localScale.y);
                Instantiate(attackEffect, attack.transform.position, attack.transform.rotation);
                cooldownTimer = 0;
            }
            else
            {
                anim.SetBool("isAttack", false);
            }
        }   
    }
}
