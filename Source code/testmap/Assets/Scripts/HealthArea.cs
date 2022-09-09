 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthArea : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip HealthSound;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player-HP") {
            collision.GetComponent<Health>().AddHealth(healthValue);
            SoundManager.Instance.PlaySound(HealthSound);
        }
    }
}
