﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class NextLvl : MonoBehaviour
{

    private void Start()
    {
        
    }

// Start is called before the first frame update
    public void Play()
    {
        int GameNum = PlayerPrefs.GetInt("LocationNum");
        int currLevel = PlayerPrefs.GetInt("currLevel");
        if (currLevel > 5)
        {
            PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
            GameNum += 1;
            PlayerPrefs.SetInt("LocationNum", GameNum);
            PlayerPrefs.SetInt("currLevel", 0);

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
                        PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
                        SceneManager.LoadScene("Game");
                        break;
                    }
                case (1):
                    {
                        PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
                        SceneManager.LoadScene("Game1");
                        break;
                    }
                case (2):
                    {
                        PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
                        SceneManager.LoadScene("Game2");
                        break;
                    }
                default:
                    {
                        SceneManager.LoadScene("Menu");
                        break;
                    }

            }
    }

    public void PlaySceneEndLevel() //Метод с задержкой что бы музыка успеваала проиграться до конца
    {
        Invoke("PlayInvoke", 3f);
    }

    void PlayInvoke()
    {
        int GameNum = PlayerPrefs.GetInt("LocationNum");
        int currLevel = PlayerPrefs.GetInt("currLevel");
        if (currLevel > 5)
        {
            PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
            GameNum += 1;
            PlayerPrefs.SetInt("LocationNum", GameNum);
            PlayerPrefs.SetInt("currLevel", 0);

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
                        PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
                        SceneManager.LoadScene("Game");
                        break;
                    }
                case (1):
                    {
                        PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
                        SceneManager.LoadScene("Game1");
                        break;
                    }
                case (2):
                    {
                        PlayerPrefs.SetInt("levelNum", PlayerPrefs.GetInt("levelNum") + 1);
                        SceneManager.LoadScene("Game2");
                        break;
                    }
                default:
                    {
                        SceneManager.LoadScene("Menu");
                        break;
                    }

            }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
