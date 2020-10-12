using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        int GameNum = PlayerPrefs.GetInt("LocationNum");
        int currLevel = PlayerPrefs.GetInt("currLevel");
        if (currLevel > 5)
        {
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
            }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
