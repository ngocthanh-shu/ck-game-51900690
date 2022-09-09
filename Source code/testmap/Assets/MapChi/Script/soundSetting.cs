using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundSetting : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("VolumeGame")){
            PlayerPrefs.SetFloat("VolumeGame", 1);
            Load();
        }
        else{
            Load();
        }
    }

    public void changeVol(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeGame");
    }
    private void Save(){
        PlayerPrefs.SetFloat("VolumeGame", volumeSlider.value);
    }
}
