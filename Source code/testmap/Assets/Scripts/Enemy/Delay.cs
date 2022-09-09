using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    void Start()
    {
        StartCoroutine("AnimationEffect");
    }
    IEnumerator AnimationEffect()
    {
        object1.SetActive(true);
        object2.SetActive(false);
        object3.SetActive(false);
        yield return new WaitForSeconds(.2f);
        object1.SetActive(false);
        object2.SetActive(true);
        object3.SetActive(false);
        yield return new WaitForSeconds(.2f);
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(true);
        yield return new WaitForSeconds(.2f);
        object3.SetActive(false);
    }
}
