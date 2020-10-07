using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Moving : MonoBehaviour
{

    public GameObject player;
    public GameObject platform;
    public GameObject correctEffect;
    public GameObject failEffect;
    public Text time;
    private string letters;
    [HideInInspector]
    public float typeSpeed = 0;
    [HideInInspector]
    public bool start = false;
    [HideInInspector]
    public bool finish = false;

    private Letter[] alp;
    private InputField inputField;
    private Vector3 toPosition;
    private Animator anim;

    private bool firstFinished = false;
    private float timeInGame = 0;
    private bool moving = false;
    private bool LReady = false;
    private int l = 0;
    private int k = 0;
    private int maxK;
    private string allLetters = "";
    private string inputText;
    private float temp = 10f;
    private float playerY = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        alp = FindObjectsOfType<Letter>();
        inputField = FindObjectOfType<InputField>();
        toPosition = player.transform.position;
        anim = player.GetComponent<Animator>();
        playerY = player.transform.position.y;
        letters = FindObjectOfType<CreatePlatformWithLetters>().letters[PlayerPrefs.GetInt("currLevel")];
        allLetters = string.Join(" ", letters);
        allLetters = allLetters.ToUpper();
        maxK = allLetters.Length;
        inputField.text = null;
        inputField.shouldHideMobileInput = true;
        inputField.onValueChanged.AddListener(delegate { ButtonPressed(); });

       FindObjectOfType<Text>().text = PlayerPrefs.GetFloat("TypeSpeed").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (time != null && !start) time.text = "10";
        inputField.Select();
        AnimatePlayer();
        FindAlphavite();
        Move(toPosition);
        TimeInGame();
        finished();
        if (time != null && start) BonusTime();
    }

    void ButtonPressed()
    {
        start = true;
        if (k == maxK) finish = true;
            if (inputField.text.Equals(allLetters[k].ToString(), StringComparison.OrdinalIgnoreCase) && !finish)
            {
                typeSpeed += 1;
                Instantiate(platform, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0, 0, 0));
                //Instantiate(correctEffect, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0, 0, 0));
                toPosition = new Vector3(alp[l].transform.position.x, playerY, alp[l].transform.position.z);
                if (k < maxK) k += 1;
                if (l > 0) l -= 1;
                inputField.text = "";
            }
            else
            //if (inputField.text!="")
            //Instantiate(failEffect, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0, 0, 0));
            //else     
            inputField.text = "";
            
    }
    void Move(Vector3 toPosition)
    {
        if (Vector3.Distance(player.transform.position, toPosition) > 0.1) moving = true; else moving = false;
        transform.position = Vector3.Lerp(player.transform.position, toPosition, 0.1f);
    }
    void TimeInGame()
    {
        if (start)
            timeInGame += Time.deltaTime;
    }
    void AnimatePlayer()
    {
        if (moving) anim.SetBool("run", true);
        else anim.SetBool("run", false);
    }
    void FindAlphavite()
    {
        if (alp.Length == 0)
        {
            alp = FindObjectsOfType<Letter>();
        }
        else
        {
            if (!LReady)
            {
                l = alp.Length;
                l -= 1;
                LReady = true;
            }
        }
    }
    void finished()
    {
        if (finish && !firstFinished)
        {
            firstFinished = true;
            typeSpeed = typeSpeed / timeInGame;
            PlayerPrefs.SetInt("TypeCount", PlayerPrefs.GetInt("TypeCount") + 1);
            PlayerPrefs.SetFloat("TypeSpeed", (PlayerPrefs.GetFloat("TypeSpeed") + typeSpeed) / PlayerPrefs.GetInt("TypeCount"));
            PlayerPrefs.SetInt("currLevel", PlayerPrefs.GetInt("currLevel") + 1);
            PlayerPrefs.Save();         
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
    void BonusTime()
    {
        if (temp > 0)
        {
            temp -= Time.deltaTime;
            time.text = temp.ToString();
        }
        else
        {
            finish = true;
        }
    }
}
