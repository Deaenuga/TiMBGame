using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonus : MonoBehaviour
{

    public GameObject[] daysPanel;

    public GameObject mainCanvas;
    public GameObject dailyCanvas;

    public Button claimButton;

    private int currDay = 0;
    private bool claimed = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("RewardedYear"));
        Debug.Log(PlayerPrefs.GetInt("RewardedMonth"));
        Debug.Log(PlayerPrefs.GetInt("RewardedDay"));
        Debug.Log(PlayerPrefs.GetInt("RewardedHour"));
        Debug.Log(PlayerPrefs.GetInt("RewardedMinute"));
        Debug.Log(PlayerPrefs.GetInt("RewardedSecond"));
        DateTime RewardedDT = new DateTime(PlayerPrefs.GetInt("RewardedYear", DateTime.Now.Year), PlayerPrefs.GetInt("RewardedMonth", DateTime.Now.Month), PlayerPrefs.GetInt("RewardedDay", DateTime.Now.Day),
                                           PlayerPrefs.GetInt("RewardedHour", DateTime.Now.Hour), PlayerPrefs.GetInt("RewardedMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("RewardedSecond", DateTime.Now.Second));
        Debug.Log(RewardedDT);
        currDay = PlayerPrefs.GetInt("currDay");
        if (RewardedDT <= DateTime.Now && (DateTime.Now - RewardedDT).Days >= 0)
        {
            panelsCreate();
        }
        else
        {
            mainCanvas.gameObject.SetActive(true);
            dailyCanvas.gameObject.SetActive(false);
        }
    }

    public void claimReward() 
    {
        DateTime RewardedDT = DateTime.Now.AddDays(1);
        PlayerPrefs.SetInt("RewardedYear", RewardedDT.Year);
        PlayerPrefs.SetInt("RewardedMonth", RewardedDT.Month);
        PlayerPrefs.SetInt("RewardedDay", RewardedDT.Day);
        PlayerPrefs.SetInt("RewardedHour", RewardedDT.Hour);
        PlayerPrefs.SetInt("RewardedMinute", RewardedDT.Minute);
        PlayerPrefs.SetInt("RewardedSecond", RewardedDT.Second);
        daysPanel[currDay].GetComponent<Image>().color = Color.red; //собрали ежедневный бонус
        if (currDay != 4)
        {
            if (!daysPanel[currDay].GetComponent<DailyBonusCount>().dolar)
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + daysPanel[currDay].GetComponent<DailyBonusCount>().value);
            else PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") + daysPanel[currDay].GetComponent<DailyBonusCount>().value);
        }
        else PlayerPrefs.SetInt("Player4", 1);
        if(currDay+1<=4)
        PlayerPrefs.SetInt("currDay", currDay + 1);
        else PlayerPrefs.SetInt("currDay", 0);
        claimed = true;
        claimButton.enabled = false;
    }

    public void closeDailyBonusPage() //По нажатию на значок выхода
    {
        if(!claimed)
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + daysPanel[currDay].GetComponent<DailyBonusCount>().value);
        mainCanvas.SetActive(true);
        dailyCanvas.SetActive(false);
    }
    private void panelsCreate()
    {
        currDay = PlayerPrefs.GetInt("currDay");
        for (int i = 0; i < daysPanel.Length; i++)
        {
            daysPanel[i].GetComponent<Image>().color = Color.grey;//Все остальные
        }
        for (int i = 0; i < currDay; i++)
        {
            daysPanel[i].GetComponent<Image>().color = Color.red; //Собранные
        }
        daysPanel[currDay].GetComponent<Image>().color = Color.yellow; //Желтый текущий день
    }
}
