using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideByTouch : MonoBehaviour
{
    public GameObject hellGate;
    public GameObject grassGate;
    public GameObject mainGate;
    private void Start(){

    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals("HellGate")){
            hellGate.SetActive(false);
            SceneManager.LoadScene("HellDungeon");
        }
        if (collision.tag.Equals("GrassGate")){
            grassGate.SetActive(false);
            SceneManager.LoadScene("GrassDungeon");
        }
        if (collision.tag.Equals("MainGate")){
            mainGate.SetActive(false);
            SceneManager.LoadScene("MainMap");
        }
    }
}
