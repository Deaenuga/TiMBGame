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
        //PlayerPrefs.SetInt("LocationNum", 0);
        PlayerPrefs.SetInt("currLevel", 0);
    }

    public void TextCoin()
    {
        textCoin.text = PlayerPrefs.GetInt("Coins").ToString();
    }
    public void PlayGame() //Метод отвечающий за переход со сцены Menu на сцену Game (расположен в объекте MainMenu)
    {
        SceneManager.LoadScene("GameBonus");
        /*int GameNum = PlayerPrefs.GetInt("LocationNum");
        int currLevel = PlayerPrefs.GetInt("currLevel");
        if (currLevel > 6) { 
            GameNum += 1; 
            PlayerPrefs.SetInt("LocationNum", GameNum);
            PlayerPrefs.SetInt("currLevel",0);
            PlayerPrefs.Save();
            switch (GameNum)
            {
                case (1):
                    {
                        SceneManager.LoadScene("GameBonus");
                        break;
                    }
                case (2):
                    {
                        SceneManager.LoadScene("Game1Bonus");
                        break;
                    }
                case (3):
                    {
                        SceneManager.LoadScene("Game2Bonus");
                        break;
                    }
                default:
                    break;
            }
        }
        else 
        switch (GameNum)
        {
            case (0):
                {
                    SceneManager.LoadScene("Game");
                    break;
                }
            case (1):
                {
                    SceneManager.LoadScene("Game1");
                    break;
                }
            case (2):
                {
                    SceneManager.LoadScene("Game2");
                    break;
                }
            default:
                break;
        } */
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
