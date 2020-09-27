using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCoinAndDollar : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreTextCoin;
    public Text ScoreTextDollar;
    void Start()
    {
        //PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 5); //Просто прибавляю 5 монет
        //scoreTextCoin.text = PlayerPrefs.GetInt("Coin").ToString();

        //PlayerPrefs.SetInt("Dollar", PlayerPrefs.GetInt("Dollar") + 1); //Просто прибавляю 5 монет
        ScoreTextDollar.text = PlayerPrefs.GetInt("Dollar").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
