using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer volMixer;
    public Slider volSlider;

    public GameObject BtnMusic;
    public bool musicButtonOn;
    public Text musicTextChange;
    public Button musicBtn;
    public GameObject soundSlider;
    

    private Image swapImg;


    
    
    
    void Start()
    {
        musicButtonOn = true;

        volSlider.value = PlayerPrefs.GetFloat("MVolume");
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
       // GameMultiLang[] textLang = FindObjectsOfType<GameMultiLang>();
        


    }

    private void FixedUpdate()
    {

        if (!musicButtonOn)
        {
            volMixer.SetFloat("volume", -60);
            musicTextChange.text = "off";
            volSlider.value = -60;
            soundSlider.SetActive(false);
            



        }
        if (musicButtonOn)
        {
            ////volSlider.value = PlayerPrefs.GetFloat("MVolume");
            //Debug.Log(PlayerPrefs.GetFloat("MVolume"));
            //volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
            soundSlider.SetActive(true);
            musicTextChange.text = "on";
        }



        //if (musicButtonOn == true)
        //{
        //    musicTextChange.text = "on";
        //}
        //if (musicButtonOn == false)
        //{
        //    musicTextChange.text = "off";
        //}


        //if (volSlider.value == -60)
        //{
        //    PlayerPrefs.SetInt("musicON", 0); //Музыка выключена
        //    musicTextChange.text = "off";

        //}


    }

    public void ChangeVol(float volume)
    {
        PlayerPrefs.SetFloat("MVolume", volume);
        volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        PlayerPrefs.Save();

    }

    public void MusicChange()
    {
        //musicButtonOn = true;
        //PlayerPrefs.SetInt("musicON", 1);
        musicButtonOn = !musicButtonOn;



        //if (musicButtonOn == true)
        //{
        //    musicTextChange.text = "on";
        //}
        //if (!musicButtonOn)
        //{
        //    musicTextChange.text = "off";
        //}

        //musicButtonOn = true;
        //PlayerPrefs.SetInt("musicON", 1);



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
