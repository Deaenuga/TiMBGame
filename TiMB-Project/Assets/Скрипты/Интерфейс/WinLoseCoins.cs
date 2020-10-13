using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseCoins : MonoBehaviour //Класс для вывода заработанных монет (на сцене конца уровня)
{

    public Text coins;
    public Text speed;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Win") == 1)
        {
            coins.text = "Заработано:" + PlayerPrefs.GetInt("currCoins").ToString();  
            //Заработанные монеты в конце уровня
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + PlayerPrefs.GetInt("currCoins"));

            PlayerPrefs.Save();
        }
        else
        {
            coins.text = "Вы ничего не заработали";
        }
        speed.text = "Символов в минуту:" + PlayerPrefs.GetFloat("typeSpeed").ToString();
    }

}
