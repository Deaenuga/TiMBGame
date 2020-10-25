using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer volMixer;
    public Slider volSlider;

    public GameObject BtnMusic;
    public Sprite musicButtonOn;
    public Sprite musicButtonOff;

    private Image swapImg;

    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume");
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));


    }

    
    public void ChangeVol(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        PlayerPrefs.Save();

    }

    public void MusicChange()
    {
        //GetComponent<Button>()..color = Color.green;
        //if (BtnMusic.GetComponent == musicButtonOn)
        //{
        //    BtnMusic.image = musicButtonOff;
        //    return;
        //}

        //if (BtnMusic.image == musicButtonOff)
        //{
        //    BtnMusic.image = musicButtonOn;
        //    return;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
