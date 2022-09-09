using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject objActive;
    public GameObject ObjInactive;

    public void OnTriggerEnter2D(Collider2D other){
        ObjInactive.SetActive(false);
        objActive.SetActive(true);
    }
}
