using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonus : MonoBehaviour
{

    public GameObject[] daysPanel;
    public Text[] daysReward;

    public Canvas mainCanvas;
    public Canvas dailyCanvas;

    public Button claimButton;

    private int currDay;
    private bool claimed = false;

    // Start is called before the first frame update
    void Start()
    {
        DateTime RewardedDT = new DateTime(PlayerPrefs.GetInt("RewardedYear", DateTime.Now.Year), PlayerPrefs.GetInt("RewardedMonth", DateTime.Now.Month), PlayerPrefs.GetInt("RewardedDay", DateTime.Now.Day),
                                           PlayerPrefs.GetInt("RewardedHour", DateTime.Now.Hour), PlayerPrefs.GetInt("RewardedMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("RewardedSecond", DateTime.Now.Second));
        if (RewardedDT <= DateTime.Now && (DateTime.Now - RewardedDT).Days == 0)
        {
            //PlayerPrefs.SetInt("currDay", 0);
            panelsCreate();
        }
        else
        if (RewardedDT < DateTime.Now && (DateTime.Now - RewardedDT).Days < 0)
        {
            PlayerPrefs.SetInt("currDay", 0);
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
        daysPanel[currDay].GetComponent<Image>().color = Color.red;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Convert.ToInt32(daysReward[currDay].text));
        PlayerPrefs.SetInt("currDay", currDay + 1);
        claimed = true;
        claimButton.enabled = false;
    }

    public void closeDailyBonusPage()
    {
        if(!claimed)
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Convert.ToInt32(daysReward[currDay].text));
        mainCanvas.gameObject.SetActive(true);
        dailyCanvas.gameObject.SetActive(false);
    }
    private void panelsCreate()
    {
        currDay = PlayerPrefs.GetInt("currDay");
        for (int i = 0; i < daysPanel.Length; i++)
        {
            daysPanel[i].GetComponent<Image>().color = Color.green;
        }
        for (int i = 0; i < currDay; i++)
        {
            daysPanel[i].GetComponent<Image>().color = Color.red;
        }
        daysPanel[currDay].GetComponent<Image>().color = Color.yellow;
    }
}
