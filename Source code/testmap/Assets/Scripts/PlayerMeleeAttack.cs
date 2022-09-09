using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float coolDownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip PunchSound;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer > attackCoolDown)
        {
            Attack();
            SoundManager.Instance.PlaySound(PunchSound);
        }

        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("isAttacking");
        coolDownTimer = 0;
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.tag == "Enemy") {
    //         Destroy(other.gameObject);
    //     }
    // }
}
