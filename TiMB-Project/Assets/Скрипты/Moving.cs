using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Threading;

public class Moving : MonoBehaviour
{

    public GameObject player;
    public GameObject platform;
    private string[] letters;

    private Letter[] alp;
    private InputField inputField;
    private Vector3 toPosition;
    private Animator anim;

    private bool moving = false;
    private bool LReady = false;
    private int l = 0;
    private int k = 0;
    private int maxK;
    private string allLetters = "";

    private float playerY = 0;
    // Start is called before the first frame update
    void Start()
    {
        alp = FindObjectsOfType<Letter>();
        inputField = FindObjectOfType<InputField>();
        toPosition = player.transform.position;
        anim = player.GetComponent<Animator>();
        playerY = player.transform.position.y;
        letters = FindObjectOfType<CreatePlatformWithLetters>().letters;
        inputField.Select();
        allLetters = string.Join(" ", letters);
        allLetters = allLetters.ToUpper();
        maxK = allLetters.Length;
        letters = FindObjectOfType<CreatePlatformWithLetters>().letters;
        allLetters = string.Join(" ", letters);
        allLetters = allLetters.ToUpper();
        inputField.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving) anim.SetBool("run", true);
        else anim.SetBool("run", false);
        ButtonPressed();
        if (alp.Length == 0)
        {
            alp = FindObjectsOfType<Letter>();
        }
        else
        {
            if(!LReady)
            {
                l = alp.Length;
                l -= 1;
                LReady = true;
            }
        }
        Move(toPosition);
    }

    void ButtonPressed()
    {
        if (inputField.text != null)
        {
            if (inputField.text.ToUpper() == allLetters[k].ToString())
            {
                Instantiate(platform, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0, 0, 0));
                toPosition = new Vector3(alp[l].transform.position.x, playerY, alp[l].transform.position.z);
                if (k < maxK - 1) k += 1;
                if (l > 0) l -= 1;
                inputField.text = null;
            }
            else
            {
                inputField.text = null;
            }
        }
    }

    void Move(Vector3 toPosition)
    {
        if (Vector3.Distance(player.transform.position, toPosition) > 0.01) moving = true; else moving = false;
        transform.position = Vector3.Lerp(player.transform.position, toPosition, 0.1f);
    }
}
