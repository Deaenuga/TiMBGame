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

            if (PlayerPrefs.GetInt("PlayerAccess" + item.index) == 1)
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
                if (buys[i].isDown && !buys[i].isDollar && !buys[i].isAccessorie)
                {
                    PlayerPrefs.SetInt("Player" + buys[i].index, 1);
                    Debug.Log("за монеты");
                    PlayerPrefs.Save();
                    UseCoins(price);
                    break;
                }

            }
        }

        if (HasEnoughDollar(price))
        {
            for (int i = 0; i < buys.Length; i++)
            {
                if (buys[i].isDown && buys[i].isDollar)
                {
                    PlayerPrefs.SetInt("Player" + buys[i].index, 1);
                    Debug.Log("за доллары");
                    PlayerPrefs.Save();
                    UseDollar(price);
                    break;
                }
            }
        }

        if (HasEnoughDollar(price))
        {
            for (int i = 0; i < buys.Length; i++)
            {
                if (buys[i].isDown && buys[i].isAccessorie)
                {
                    PlayerPrefs.SetInt("PlayerAccess" + buys[i].index, 1);
                    Debug.Log("акксесуар");
                    PlayerPrefs.Save();
                    UseDollar(price);
                    break;
                }
            }
        }


    }
    public bool HasEnoughCoins(int amount) //Если было достаточно монет
    {
        return (PlayerPrefs.GetInt("Coins") >= amount);
    }

    public bool HasEnoughDollar(int amount) //Если Было достаточно долларов
    {
        return (PlayerPrefs.GetInt("Dollar") >= amount);
    }

    public void UseCoins(int amount) //Отнимание суммы
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - amount);
        GameObject.FindGameObjectWithTag("BuyButton").GetComponent<Button>().interactable = false;
        PlayerPrefs.Save();
    }

    public void UseDollar(int amount) //Отнимание суммы
    {
        PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") - amount);
        GameObject.FindGameObjectWithTag("BuyButton").GetComponent<Button>().interactable = false;
        PlayerPrefs.Save();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
