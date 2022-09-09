using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDamaged : MonoBehaviour
{
    [SerializeField] private int hp;
    public GameObject enemy;
    private Animator anim;
    private EnemyAI ai;
    void Start()
    {
        hp = 10;
        anim = enemy.GetComponent<Animator>();
        ai = enemy.GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            ai.speed = 0;
            anim.SetBool("isDie", true);
            Destroy(enemy,2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hp -= 5;
        }
    }
}
