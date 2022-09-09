using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDamagedGen2 : MonoBehaviour
{
    [SerializeField] private int hp;
    public GameObject enemy;
    private Animator anim;
    private EnemyAIGen2 ai;
    [SerializeField] private float Cooldown;
    private float cooldownTimer;
    void Start()
    {
        cooldownTimer = Mathf.Infinity;
        anim = enemy.GetComponent<Animator>();
        ai = enemy.GetComponent<EnemyAIGen2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            ai.speed = 0;
            anim.SetBool("isDie", true);
            Destroy(enemy, 2f);
        }
        cooldownTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (cooldownTimer > Cooldown)
            {
                hp -= 5;
                cooldownTimer = 0;
            }
        }
    }
}
