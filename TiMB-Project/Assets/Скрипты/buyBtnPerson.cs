using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buyBtnPerson : MonoBehaviour
{
    //public int Price;
    public int index;
    public GameObject modelSkin;
    [HideInInspector]
    public bool isDown = false;
    
    //public Button BuyButton;

    public void Pressed()
    {

        buyBtnPerson[] buttons = FindObjectsOfType<buyBtnPerson>();
        foreach (var item in buttons)
        {
            item.isDown = false;
        }
        isDown = true;

        PlayerPrefs.SetInt("currSkin", index); //При нажатии запоминает какой скин
        PlayerPrefs.Save();


        for (int i = 0; i < buttons.Length; i++)
        {

            // modelSkin.SetActive(false);
            if (buttons[i].index != index) //Если кнопка не выбрана
            {
                //modelSkin.SetActive(false);
                Debug.Log(index);
                buttons[i].GetComponent<Image>().color = Color.white;
                buttons[i].modelSkin.SetActive(false);

            }
            else
            {
                //Выбран элемент
                for (int k = 0; k < buttons.Length; k++)
                {
                    if (k != i)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        modelSkin.SetActive(true);
                        Debug.Log("моделька");

                    }

                }


                //if (PlayerPrefs.GetInt("Player" + numPlayer) == 0)
                //{
                //    //BuyButton.GetComponentInChildren<Text>().text = Price.ToString(); //Выводим значение денег в кнопку
                //    BuyButton.interactable = true;
                //}
                //else BuyButton.GetComponentInChildren<Text>().text = "Куплено";
            }


        }
    }
}
