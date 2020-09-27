using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buyBtn : MonoBehaviour
{
    public int Price;
    public GameObject model;
    [HideInInspector]
    public bool isDown=false;
    public int index;
    public Button BuyButton; 
    public void Pressed()
    {
        buyBtn[] buttons = FindObjectsOfType<buyBtn>();
        foreach (var item in buttons)
        {
            item.isDown = false;
        }
        isDown = true;
        for (int i = 0; i < buttons.Length; i++)
        {         
            if (buttons[i].index!=index)
            {
                buttons[i].GetComponent<Image>().color = Color.white;         
            }
            else
            {
                this.GetComponent<Image>().color = Color.red;
                if(PlayerPrefs.GetInt("Player"+index)==0)
                BuyButton.GetComponentInChildren<Text>().text = Price.ToString();
                else BuyButton.GetComponentInChildren<Text>().text = "Куплено";
            }
        }
    }
}
