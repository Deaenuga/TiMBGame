using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{

    public Text textCoin;

    void Start()
    {
        TextCoin(); 
        PlayerPrefs.SetInt("LocationNum", 0);
        PlayerPrefs.SetInt("currLevel", 0);
    }

    public void TextCoin()
    {
        textCoin.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void QuitGame() //Метод отвечащий за выход из игры (расположен в объекте MainMenu)
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }

    public void GoToShop() //Метод отвечающий за переход со сцены Menu на сцену Shop
    {
        SceneManager.LoadScene("Shop");

    }

    public void GoToPerson()
    {
        SceneManager.LoadScene("Person");
    }

}
