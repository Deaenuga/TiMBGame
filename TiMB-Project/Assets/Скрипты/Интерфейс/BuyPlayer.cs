using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPlayer : MonoBehaviour
{
    public int numPlayer;
    public void ChangePlayer()
    {
        PlayerPrefs.SetInt("currSkin", numPlayer);
        PlayerPrefs.Save();
    }
}
