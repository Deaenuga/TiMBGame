using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEndLevel : MonoBehaviour
{
    // Start is called before the first frame update

    //Объекты для работы с меню победы
    public GameObject[] hiddenObjects;

    public void MenuEnd()
    {
        for (int i = 0; i < hiddenObjects.Length; i++)
        {
            hiddenObjects[i].SetActive(false);
        }
    }
}
