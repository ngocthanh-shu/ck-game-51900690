using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public Animator anim;

    private float x, y;
    private bool isWalking;

    private Vector3 moveDir;

    private bool isDash;
    [SerializeField] private float dashCoolDown;
    private float coolDownTimer = Mathf.Infinity;

    [SerializeField] private LayerMask dashLayerMask;
    [SerializeField] float dashDistance = 5f;
    public ParticleSystem dashEffect;

    public Camera cam;
    public Vector2 mousePos;

    [SerializeField] private AudioClip TeleSound;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x > 0.01f)
        {
            transform.localScale = new Vector3(0.3f ,0.3f , 1);
        }
        else if (x < -0.01f)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1);
        }

        if (x != 0 || y != 0)
        {
            anim.SetFloat("x", x);
            anim.SetFloat("y", y);

            if (!isWalking)
            {
                isWalking = true;
                anim.SetBool("isMoving", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("isMoving", isWalking);
                StopMoving();
            }
        }

        moveDir = new Vector3(x, y).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && coolDownTimer > dashCoolDown) { 
            isDash = true;
            dashEffect.Play();
            
        }

        coolDownTimer += Time.deltaTime;
    }

    private void FixedUpdate() {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;

        if (isDash) {
            SoundManager.Instance.PlaySound(TeleSound);
            Vector3 dashPosition = transform.position + moveDir * dashDistance;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashDistance, dashLayerMask);
            if (raycastHit2d.collider != null) {
                dashPosition = raycastHit2d.point;
            }

            rb.MovePosition(dashPosition);
            coolDownTimer = 0;
            isDash = false;
        }
    }

    private void StopMoving() {
        rb.velocity = Vector3.zero;
    }
}
