using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;
    private string[] letters;

    private Letter[] alp;
    private TMP_InputField inputField;

    private int l;
    private int k;
    private int maxK;
    private string allLetters = "";
    // Start is called before the first frame update
    void Start()
    {
        alp = FindObjectsOfType<Letter>();
        letters = FindObjectOfType<CreatePlatformWithLetters>().letters;
        inputField = FindObjectOfType<TMP_InputField>();

        for (int i = 0; i < letters.Length; i++)
        {
            for (int j = 0; j < letters[i].Length; j++)
            {
                if ((letters[i][j] != ' ') && (letters[i][j] != ',') && (letters[i][j] != '!') && (letters[i][j] != '?') && (letters[i][j] != '.') && (letters[i][j] != '-'))
                {
                    allLetters += letters[i][j];
                }
            }
        }
        k = 0;
        maxK = allLetters.Length;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonPressed();
        if (alp.Length == 0)
        {
            alp = FindObjectsOfType<Letter>();
            l = alp.Length;
            l--;
        }
    }

    void ButtonPressed()
    {
        //Debug.Log(inputField.text);
        if (inputField.text.ToLower() == allLetters[k].ToString().ToLower())
        {
            Instantiate(platform, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0,0,0));
            if (k < maxK-1) k++;
            if (l > 0) l--;
            inputField.text = null;
            player.transform.position = new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z);
        }
        else inputField.text = null;
    }
}
