using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class WinLoseCoins : MonoBehaviour //Класс для вывода заработанных монет (на сцене конца уровня)
{

    public Text coins;
    public Text speed; //количество набранных символов
    public GameObject buttonWin;
    public GameObject buttonLose;
    public GameObject BtnVideoX2;


    // Start is called before the first frame update
    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3860680", false);
        }

        if (PlayerPrefs.GetInt("Win") == 1)
        {
            buttonLose.SetActive(false);
            buttonWin.SetActive(true);

            
            if(PlayerPrefs.GetInt("LocationNum")>0 && PlayerPrefs.GetInt("currLevel")==1)
            {
                coins.text = "Заработано:" + PlayerPrefs.GetInt("currCoins").ToString();
                //Заработанные монеты в конце уровня
                PlayerPrefs.SetInt("Dollars", PlayerPrefs.GetInt("Dollars") + PlayerPrefs.GetInt("currCoins"));
                PlayerPrefs.Save();
            }
            else
            {
                coins.text = "Заработано:" + PlayerPrefs.GetInt("currCoins").ToString();
                //Заработанные монеты в конце уровня
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + PlayerPrefs.GetInt("currCoins"));
                PlayerPrefs.Save();
            }
        }
        else
        {
            buttonLose.SetActive(true);
            buttonWin.SetActive(false);
            coins.text = "Вы ничего не заработали";

        }

        speed.text = "Символов в минуту:" + PlayerPrefs.GetFloat("typeSpeed").ToString();
    }

    public void ButtonVideoAdvertisingX2() //Метод увеличения заработанных монет на уровне в два раза
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo"); //Вид рекламы который можно пропустить
        }
        if (PlayerPrefs.GetInt("LocationNum") > 0 && PlayerPrefs.GetInt("currLevel") == 1)
        {
            PlayerPrefs.SetInt("Dollars", PlayerPrefs.GetInt("Dollars") + (PlayerPrefs.GetInt("currCoins")));         //Полученные доллары на уровне увеличиваем в два раза
        }
        else
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + (PlayerPrefs.GetInt("currCoins")));         //Полученные монеты на уровне увеличиваем в два раза
        }

        BtnVideoX2.SetActive(false);
        //BtnVideoX2.GetComponentInChildren<Text>().text = "😅";
    }


}
