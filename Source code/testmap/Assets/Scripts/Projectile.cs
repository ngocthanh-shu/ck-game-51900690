using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
            Destroy(gameObject);

        // if (other.tag == "Wall") {
        //     gameObject.SetActive(false);
        // }
    }

}
