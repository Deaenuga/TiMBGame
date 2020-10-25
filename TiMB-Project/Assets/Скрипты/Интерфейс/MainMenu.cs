using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;



public class MainMenu : MonoBehaviour
{

    public Text textCoin;
    public Text textDollar;
    public Text currlevel;
    public AudioSource audioSource;

    void Start()
    {
        if (PlayerPrefs.GetInt("FirstStart")==0)
        {
            PlayerPrefs.SetInt("PlayerAccess", -1);
            PlayerPrefs.SetInt("LocationNum", 0);
            PlayerPrefs.SetInt("currLevel", 0);
            PlayerPrefs.SetInt("levelNum", 1);
            PlayerPrefs.SetInt("FirstStart", 1);
        }
        TextCoin(); 
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3860680", false);
        }
        currlevel.text += " " + PlayerPrefs.GetInt("levelNum").ToString();
        
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
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video"); //Вид рекламы который можно пропустить
        }
        SceneManager.LoadScene("Person");
    }

}
