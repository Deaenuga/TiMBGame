using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Advertisements;
using System;

public class MainMenu : MonoBehaviour
{

    public Text textCoin;
    public Text textDollar;
    public Text currlevel;
    public AudioSource audioSource;
    public AudioMixer mixerMusic;
    public AudioMixer mixerSound;



    void Start()
    {
        // PlayerPrefs.SetInt("FirstStart", 0);
        EraseAll();
        TextCoin();

        //volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
        if (PlayerPrefs.GetInt("MUTED Music") == 1)
        {
            //AudioListener.pause = true;
            mixerMusic.SetFloat("volume", 0);
        }
        if (PlayerPrefs.GetInt("MUTED Music") == 0)
        {
            //AudioListener.pause = false;
            mixerMusic.SetFloat("volume", -80);
        }


        if (PlayerPrefs.GetInt("MUTED Sound") == 1)
        {
            //AudioListener.pause = true;
            mixerSound.SetFloat("volumeSound", 0);
        }
        if (PlayerPrefs.GetInt("MUTED Sound") == 0)
        {
            //AudioListener.pause = false;
            mixerSound.SetFloat("volumeSound", -80);
        }





        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3860680", false);
        }
        currlevel.text += " " + PlayerPrefs.GetInt("levelNum").ToString();

        //volMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));

    }

    private void Update()
    {
        TextCoin();
    }
    public void TextCoin()
    {
        textCoin.text = PlayerPrefs.GetInt("Coins").ToString();
        textDollar.text = PlayerPrefs.GetInt("Dollar").ToString();
    }

    public void QuitGame() //Метод отвечащий за выход из игры (расположен в объекте MainMenu)
    {
        Debug.Log("Выход из игры");
        Invoke("Quit", 0.5f);
        
    }

    void Quit()
    {
        Application.Quit();
    }



    public void GoToShop() //Метод отвечающий за переход со сцены Menu на сцену Shop
    {
        Invoke("LoadNewScene", 0.5f);
    }

    void LoadNewScene()
    {
        SceneManager.LoadScene("Shop");
    }



    public void GoToPerson()
    {
        //if (Advertisement.IsReady())
        //{
        //    Advertisement.Show("video"); //Вид рекламы который можно пропустить
        //}
        SceneManager.LoadScene("Person");
    }

    public void EraseAll()
    {
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
            PlayerPrefs.SetInt("TypeCount", 0);
            PlayerPrefs.SetInt("TypeSpeed", 0);
            PlayerPrefs.SetInt("RewardedYear", DateTime.Now.Year - 1);
            PlayerPrefs.SetInt("RewardedMonth", DateTime.Now.Month - 1);
            PlayerPrefs.SetInt("RewardedDay", DateTime.Now.Day - 1);
            PlayerPrefs.SetInt("RewardedHour", DateTime.Now.Hour - 1);
            PlayerPrefs.SetInt("RewardedMinute", DateTime.Now.Minute - 1);
            PlayerPrefs.SetInt("RewardedSecond", DateTime.Now.Second - 1);
            PlayerPrefs.SetInt("PlayerAccess", -1);
            PlayerPrefs.SetInt("LocationNum", 0);
            PlayerPrefs.SetInt("currLevel", 0);
            PlayerPrefs.SetInt("Coins", 10000);
            PlayerPrefs.SetInt("Dollar", 10000);
            PlayerPrefs.SetInt("levelNum", 1);
            PlayerPrefs.SetInt("FirstStart", 1);
            PlayerPrefs.SetInt("Player0", 0);
            PlayerPrefs.SetInt("Player1", 0);
            PlayerPrefs.SetInt("Player2", 0);
            PlayerPrefs.SetInt("Player3", 0);
            PlayerPrefs.SetInt("Player4", 0);
            PlayerPrefs.SetInt("Player5", 0);
            PlayerPrefs.SetInt("Player6", 0);
            PlayerPrefs.SetInt("Player7", 0);
            PlayerPrefs.SetInt("Player8", 0);
            PlayerPrefs.SetInt("Player9", 0);
            PlayerPrefs.SetInt("Player10", 0);
            PlayerPrefs.SetInt("Player11", 0);
            PlayerPrefs.SetInt("Player12", 0);
            PlayerPrefs.SetInt("Player13", 0);
            PlayerPrefs.SetInt("Player14", 0);
            PlayerPrefs.SetInt("Player15", 0);
            PlayerPrefs.SetInt("Player16", 0);
            PlayerPrefs.SetInt("Player17", 0);
            PlayerPrefs.SetInt("PlayerAccess0", 0);
            PlayerPrefs.SetInt("PlayerAccess1", 0);
            PlayerPrefs.SetInt("PlayerAccess2", 0);
            PlayerPrefs.SetInt("PlayerAccess3", 0);
            PlayerPrefs.SetInt("PlayerAccess4", 0);
            PlayerPrefs.SetInt("PlayerAccess5", 0);
            PlayerPrefs.SetInt("PlayerAccess6", 0);
            PlayerPrefs.SetInt("PlayerAccess7", 0);
            PlayerPrefs.SetInt("PlayerAccess8", 0);
            PlayerPrefs.SetInt("PlayerAccess9", 0);
            PlayerPrefs.SetInt("PlayerAccess10", 0);
            PlayerPrefs.SetInt("PlayerAccess11", 0);
            PlayerPrefs.SetInt("PlayerAccess12", 0);
            PlayerPrefs.SetInt("PlayerAccess13", 0);
            PlayerPrefs.SetInt("PlayerAccess14", 0);
            PlayerPrefs.SetInt("PlayerAccess15", 0);
            PlayerPrefs.SetInt("PlayerAccess16", 0);
            PlayerPrefs.SetInt("PlayerAccess17", 0);
            PlayerPrefs.SetInt("PlayerAccess18", 0);
            PlayerPrefs.SetInt("PlayerAccess19", 0);
            PlayerPrefs.SetInt("PlayerAccess20", 0);
            PlayerPrefs.SetInt("PlayerAccess21", 0);
            PlayerPrefs.SetInt("PlayerAccess22", 0);
            PlayerPrefs.SetInt("PlayerAccess23", 0);
            PlayerPrefs.SetInt("PlayerAccess24", 0);
            PlayerPrefs.SetInt("PlayerAccess25", 0);
            PlayerPrefs.SetInt("PlayerAccess26", 0);
        }
    }
}
