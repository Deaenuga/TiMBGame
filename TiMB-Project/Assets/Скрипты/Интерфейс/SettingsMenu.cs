using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer mixerMusic;
    public AudioMixer mixerSound;

    public Text musicTextChange;
    public Text soundTextChange;


    public bool isMutedMusic; //музыка отключена 
    public int  isValueMutedMusic;

    public bool isMutedSound; //звуки отключена 
    public int  isValueMutedSound;





    void Start()
    {
        if(PlayerPrefs.GetInt("MUTED Music") == 0) //выключена
        {
            isMutedMusic = true;
            isValueMutedMusic = -80;
            musicTextChange.text = "off";
        }
        if (PlayerPrefs.GetInt("MUTED Music") == 1)//включена
        {
            isMutedMusic = false;
            isValueMutedMusic = 0;
            musicTextChange.text = "on";
        }
        mixerMusic.SetFloat("volume", isValueMutedMusic);


        if (PlayerPrefs.GetInt("MUTED Sound") == 0) //выключена
        {
            isMutedSound = true;
            isValueMutedSound = -80;
            soundTextChange.text = "off";
        }
        if (PlayerPrefs.GetInt("MUTED Sound") == 1)//включена
        {
            isMutedSound = false;
            isValueMutedSound = 0;
            soundTextChange.text = "on";
        }
        mixerSound.SetFloat("volumeSound", isValueMutedSound);

        //AudioListener.pause = isMuted;


    }

    private void FixedUpdate()
    {

        //if (musicButtonOn)
        //{
        //    PlayerPrefs.SetFloat("MVolume", 1);
        //    volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        //    PlayerPrefs.Save();
        //    ////volSlider.value = PlayerPrefs.GetFloat("MVolume");
        //    //Debug.Log(PlayerPrefs.GetFloat("MVolume"));
        //    //volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        //    //soundSlider.SetActive(true);
        //    musicTextChange.text = "on";
        //}

        //if (!musicButtonOn)
        //{
        //    //volMixer.SetFloat("volume", -60);

        //    //volSlider.value = -60;
        //    //soundSlider.SetActive(false);
        //    PlayerPrefs.SetFloat("MVolume", -80);
        //    volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        //    PlayerPrefs.Save();

        //    musicTextChange.text = "off";



        //}


    }


    public void MusicChange()
    {
        isMutedMusic = !isMutedMusic;
        //AudioListener.pause = isMuted;
        if (isMutedMusic == false)
        {
            isValueMutedMusic = 0;
            mixerMusic.SetFloat("volume", isValueMutedMusic);
            PlayerPrefs.SetInt("MUTED Music", 1);
            musicTextChange.text = "on";
        }
        if (isMutedMusic == true)
        {
            isValueMutedMusic = -80;
            mixerMusic.SetFloat("volume", isValueMutedMusic);
            PlayerPrefs.SetInt("MUTED Music", 0);
            musicTextChange.text = "off";
        }
        PlayerPrefs.Save();
        
    }


    public void SoundChange()
    {
        isMutedSound = !isMutedSound;
        //AudioListener.pause = isMuted;
        if (isMutedSound == false)
        {
            isValueMutedSound = 0;
            mixerSound.SetFloat("volumeSound", isValueMutedSound);
            PlayerPrefs.SetInt("MUTED Sound", 1);
            soundTextChange.text = "on";
        }
        if (isMutedSound == true)
        {
            isValueMutedSound = -80;
            mixerSound.SetFloat("volumeSound", isValueMutedSound);
            PlayerPrefs.SetInt("MUTED Sound", 0);
            soundTextChange.text = "off";
        }
        PlayerPrefs.Save();

    }

}
