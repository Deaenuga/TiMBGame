using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("TypeCount")==0)
        {
            this.GetComponent<Text>().text = "Мы не знаем вашу скорость печати";
        }
        else
        {
            this.GetComponent<Text>().text = "Ваша средняя скорость печати:"+Math.Round(PlayerPrefs.GetFloat("TypeSpeed"),2)+" символа в секунду!";
        }
    }

}
