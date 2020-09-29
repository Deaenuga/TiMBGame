using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyPlayer : MonoBehaviour
{
    private int numPlayer;
    private buyBtn[] buys;


    public void ChangePlayer()
    {
        PlayerPrefs.SetInt("currSkin", numPlayer); //При нажатии запоминает какой скин
        PlayerPrefs.Save();
    }


    void Start()
    {
        buys = FindObjectsOfType<buyBtn>();
    }
    private void Update()
    {
        foreach (var item in buys)
        {
            if (PlayerPrefs.GetInt("Player" + item.index) == 1)
            {
                item.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void Buy()
    {
        int price = Convert.ToInt32(GameObject.FindGameObjectWithTag("BuyButton").GetComponentInChildren<Text>().text);
        if (HasEnoughCoins(price))
        {
            for (int i = 0; i < buys.Length; i++)
            {
                if (buys[i].isDown)
                {
                    PlayerPrefs.SetInt("Player" + buys[i].index, 1);
                    PlayerPrefs.Save();
                    UseCoins(price);
                    break;
                }
            }
        }

    }
    public bool HasEnoughCoins(int amount) //если Было достаточно монет
    {
        return (PlayerPrefs.GetInt("Coins") >= amount);
    }

    public void UseCoins(int amount) //Отнимание суммы
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - amount);
        PlayerPrefs.Save();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
