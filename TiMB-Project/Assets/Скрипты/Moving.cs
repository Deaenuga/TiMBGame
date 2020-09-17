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
    private Vector3 toPosition;

    private int l;
    private int k;
    private int maxK;
    private string allLetters = "";

    public float speed = 1;

    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        alp = FindObjectsOfType<Letter>();
        letters = FindObjectOfType<CreatePlatformWithLetters>().letters;
        inputField = FindObjectOfType<TMP_InputField>();
        toPosition = player.transform.position;


        inputField.Select();

        for (int i = 0; i < letters.Length; i++)
        {
            for (int j = 0; j < letters[i].Length; j++)
            {
                if ((letters[i][j] != ',') && (letters[i][j] != '!') && (letters[i][j] != '?') && (letters[i][j] != '.') && (letters[i][j] != '-'))
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
        Move(toPosition);
    }

    void ButtonPressed()
    {
        //Debug.Log(inputField.text);
        if (inputField.text.ToLower() == allLetters[k].ToString().ToLower())
        {
            Instantiate(platform, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0,0,0));
            toPosition = new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z);
            if (k < maxK-1) k++;
            if (l > 0) l--;
            inputField.text = null;
        }
        else inputField.text = null;
    }

    void Move(Vector3 toPosition)
    {
        progress += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(player.transform.position, toPosition, progress);
    }
}
