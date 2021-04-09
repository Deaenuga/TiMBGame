using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class NextLvl : MonoBehaviour
{
    public void Play()
    {
        int currLevel;
        int GameNum;
        string lang = PlayerPrefs.GetString("_language");
        if (lang == "ru")
        {
            currLevel = PlayerPrefs.GetInt("currLevelRu");
            GameNum = PlayerPrefs.GetInt("LocationNumRu");
        }
        else
        {
            currLevel = PlayerPrefs.GetInt("currLevelEng");
            GameNum = PlayerPrefs.GetInt("LocationNumEng");
        }
        if (currLevel==20)
        {
            GameNum += 1;
            if (lang == "ru")
            {
                PlayerPrefs.SetInt("currLevelRu", 0);
                PlayerPrefs.SetInt("LocationNumRu", GameNum);
            }
            else
            {
                PlayerPrefs.SetInt("currLevelEng", 0);
                PlayerPrefs.SetInt("LocationNumEng", GameNum);
            }
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
        else if(currLevel==6 || currLevel == 13)
        {
            switch (GameNum)
            {
                case (0):
                    {
                        SceneManager.LoadScene("GameBonus");
                        break;
                    }
                case (1):
                    {
                        SceneManager.LoadScene("Game1Bonus");
                        break;
                    }
                case (2):
                    {
                        SceneManager.LoadScene("Game2Bonus");
                        break;
                    }
                default:
                    break;
            }
        } else
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
                    {
                        SceneManager.LoadScene("Menu");
                        break;
                    }

            }
    }

    public void PlaySceneEndLevel() //Метод с задержкой что бы музыка успевала доиграть до конца
    {
        //Invoke("PlayInvoke", 3f);
        PlayInvoke();
    }

    void PlayInvoke()
    {
        int currLevel;
        int GameNum;
        string lang = PlayerPrefs.GetString("_language");
        if (lang == "ru")
        {
            currLevel = PlayerPrefs.GetInt("currLevelRu");
            GameNum = PlayerPrefs.GetInt("LocationNumRu");
        }
        else
        {
            currLevel = PlayerPrefs.GetInt("currLevelEng");
            GameNum = PlayerPrefs.GetInt("LocationNumEng");
        }
        if (currLevel == 20)
        {
            GameNum += 1;
            if (lang == "ru")
            {
                PlayerPrefs.SetInt("currLevelRu", 0);
                PlayerPrefs.SetInt("LocationNumRu", GameNum);
            }
            else
            {
                PlayerPrefs.SetInt("currLevelEng", 0);
                PlayerPrefs.SetInt("LocationNumEng", GameNum);
            }
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
        else if (currLevel == 6 || currLevel == 13)
        {
            switch (GameNum)
            {
                case (0):
                    {
                        SceneManager.LoadScene("GameBonus");
                        break;
                    }
                case (1):
                    {
                        SceneManager.LoadScene("Game1Bonus");
                        break;
                    }
                case (2):
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
