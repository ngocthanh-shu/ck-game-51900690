using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loadlevel : MonoBehaviour
{
    public Button[] lvBtn;
    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt",2);

        for (int i =0; i <lvBtn.Length; i++)
        {
            if(i+ 2 > levelAt){
                lvBtn[i].interactable = false;
            }

        }

    }

    public void resetLevel ()
    {
        PlayerPrefs.SetInt("levelAt",2);
        int levelAt = PlayerPrefs.GetInt("levelAt");
        for (int i =0; i <lvBtn.Length; i++)
        {
            if(i+ 2 > levelAt){
                lvBtn[i].interactable = false;
            }

        }
    }

}
