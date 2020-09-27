using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPlayer : MonoBehaviour
{
    public int numPlayer;
    public int Price;
    public Button buyBtn;
    //Делать кнопку активной IsPurchased

    //public Text[] allCoinsUIText;


    public void ChangePlayer()
    {
        OnShopItemBtnClicked(numPlayer);
        //PlayerPrefs.SetInt("currSkin", numPlayer); //При нажатии запоминает какой скин
        PlayerPrefs.Save();
    }


    void Start()
    {
        PlayerPrefs.SetInt("Player1", 1);
        PlayerPrefs.SetInt("Player2", 1);




    }





    void OnShopItemBtnClicked(int itemIndex) //При нажатии на кнопку делать
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    PlayerPrefs.GetInt("numPlayer");
        //}

        if (HasEnoughCoins(Price)) //Если Было достаточно монет
        {
            UseCoins(Price); //Отнимаем от PlayerPrefs стоимость самого скина
            
            DisableBuyButton(); //Делаем кнопку недействительной
            PlayerPrefs.SetInt("Player1", 1);

        }
        else
        {
            
            Debug.Log("У вас недостаточно денег!!");
        }
    }

    void DisableBuyButton()
    {
        buyBtn.interactable = false;
        //buyBtn.transform.GetChild(0).GetComponent<Text>().text = "Куплено";
    }



    public bool HasEnoughCoins(int amount) //если Было достаточно монет
    {
        return (PlayerPrefs.GetInt("Coins") >= amount);
    }

    public void UseCoins(int amount) //Отнимание суммы
    {
        //Coins -= amount;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - amount);
        PlayerPrefs.Save();
    }
}
