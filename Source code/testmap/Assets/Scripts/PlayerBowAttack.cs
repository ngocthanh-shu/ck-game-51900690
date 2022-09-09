using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    private Animator anim;
    [SerializeField] private AudioClip ArrowsSound;
    [SerializeField] private float attackCoolDown;
    private float coolDownTimer = Mathf.Infinity;

    public float arrowForce = 20f;

    public Camera cam;

    Vector2 mousePos;

    private Transform player;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && coolDownTimer > attackCoolDown) {
            Shoot(); 
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        coolDownTimer += Time.deltaTime;

        
    }

    void Shoot() {
        SoundManager.Instance.PlaySound(ArrowsSound);
        anim.SetTrigger("isRangedAttacking");

        // GameObject arrow = Instantiate(arrowPrefab, mousePos, firePoint.rotation);
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        coolDownTimer = 0;
    }
}
