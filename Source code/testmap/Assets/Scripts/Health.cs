using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private Behaviour[] component;

    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    public GameObject deadText;
    public GameObject restartBtn;


    public void Start(){
        if (deadText == null)
            deadText = GameObject.FindWithTag("deadText");
        if (restartBtn == null)
            restartBtn = GameObject.FindWithTag("restartBtn");
            
        deadText.SetActive(false);
        restartBtn.SetActive(false);
    }
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        currentHealth -= _damage;

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.Instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                foreach (Behaviour comp in component)
                {
                    comp.enabled = false;
                }
                dead = true;

                SoundManager.Instance.PlaySound(deathSound);
            }
        }
    }

    private void Update() {
        if (dead)
        {
            deadText.SetActive(true);
            restartBtn.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy hit")
        {
            TakeDamage(1);
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
