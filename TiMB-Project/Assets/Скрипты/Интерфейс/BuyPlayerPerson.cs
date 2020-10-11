using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyPlayerPerson : MonoBehaviour
{
    private buyBtnPerson[] buys;
    // Start is called before the first frame update

    void Start()
    {
        buys = FindObjectsOfType<buyBtnPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in buys)
        {
            if (PlayerPrefs.GetInt("Player" + item.index) == 1)
            {
                item.GetComponent<Button>().interactable = true;
                

            }
            if (PlayerPrefs.GetInt("Player" + item.index) == 0)
            {
                //item.GetComponent<Button>().interactable = false;
                Debug.LogWarning("adad");
                item.GetComponent<Button>().interactable = false;


            }
        }
    }
}
