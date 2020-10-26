using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyPlayerPerson : MonoBehaviour
{
    private buyBtnPerson[] buys;

    void Start()
    {
        buys = FindObjectsOfType<buyBtnPerson>();

        foreach (var item in buys)
        {
            if (PlayerPrefs.GetInt("Player" + item.index) == 1)
            {

                item.GetComponent<Button>().interactable = true;


            }

            if (PlayerPrefs.GetInt("Player" + item.index) == 0)
            {
                item.GetComponent<Button>().onClick.RemoveAllListeners();
                Destroy(item.gameObject);
                print(item.GetComponent<Button>().IsDestroyed());
            }
            //if (PlayerPrefs.GetInt("Player" + item.index) == 0)
            //{
            //    //item.GetComponent<Button>().interactable = false;
            //    //Destroy(this.gameObject);
            //    Debug.LogWarning("adad");
            //    item.GetComponent<Button>().enabled = false;
            //    item.GetComponent<Button>().interactable = false;
            //    item.GetComponent<Button>().enabled = false;
            //    item.GetComponent<Button>().interactable = false;
            //    Destroy(item.GetComponent<Button>());
            //}
        }
    }

}
