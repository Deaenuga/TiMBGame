using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAccessoryPerson : MonoBehaviour
{
    public int index;
    [HideInInspector]
    public bool isDown = false;

    private SelectAccessoryPerson[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectsOfType<SelectAccessoryPerson>();
        if (index == PlayerPrefs.GetInt("PlayerAccess"))
            SetActive();
    }

    public void Pressed()
    {
        foreach (var item in buttons)
        {
            item.isDown = false;
        }
        isDown = true;

        PlayerPrefs.SetInt("PlayerAccess", index); //При нажатии запоминает какой скин
        PlayerPrefs.Save();

        SetActive();

    }
    void SetActive()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].index != index) //Если кнопка не выбрана
            {
                buttons[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                for (int k = 0; k < buttons.Length; k++)
                {
                    if (k != i)
                    {
                        this.GetComponent<Image>().color = Color.green;

                    }

                }
            }
        }
    }
}
