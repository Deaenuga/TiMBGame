﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject[] playerModels;
    void Start()
    {
       PlayerPrefs.SetInt("Coins", 5000);
        PlayerPrefs.SetInt("Player0", 0);
        PlayerPrefs.SetInt("Player1", 0);
        PlayerPrefs.SetInt("Player2", 0);
        PlayerPrefs.SetInt("Player3", 0);
        PlayerPrefs.SetInt("Player4", 0);
        PlayerPrefs.SetInt("Player5", 0);


    }





}




