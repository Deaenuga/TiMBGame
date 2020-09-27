using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text[] allCoinsUIText;

    void Update()
    {
        UpdateAllCoinsUIText();
    }
    public void UpdateAllCoinsUIText()
    {
        for (int i = 0; i < allCoinsUIText.Length; i++)
        {
            allCoinsUIText[i].text = PlayerPrefs.GetInt("Coins").ToString();
        }
    }
}
