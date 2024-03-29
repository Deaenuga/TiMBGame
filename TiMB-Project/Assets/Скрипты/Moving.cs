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
    public Text coins;
    private string letters;
    [HideInInspector]
    public float typeSpeed = 0;
    [HideInInspector]
    public bool start = false;
    [HideInInspector]
    public bool finish = false;
    [HideInInspector]
    public bool paused = false;

    private Letter[] alp;
    private InputField inputField;
    private Vector3 toPosition;
    private Animator anim;

    public bool bonus;
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
        PlayerPrefs.SetInt("currCoins", 0);
        Application.targetFrameRate = 60;
        alp = FindObjectsOfType<Letter>();
        inputField = FindObjectOfType<InputField>();
        toPosition = player.transform.position;
        anim = player.GetComponent<Animator>();
        playerY = player.transform.position.y;
        string lang = PlayerPrefs.GetString("_language", "ru");
        if(lang=="ru")
        letters = FindObjectOfType<CreatePlatformWithLetters>().letters[PlayerPrefs.GetInt("currLevelRu")];
        else letters = FindObjectOfType<CreatePlatformWithLetters>().letters[PlayerPrefs.GetInt("currLevelEng")];
        allLetters = string.Join(" ", letters);
        allLetters = allLetters.ToUpper();
        maxK = allLetters.Length;
        inputField.text = null;
        inputField.shouldHideMobileInput = true;
        inputField.onValueChanged.AddListener(delegate { ButtonPressed(); });
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused && !TouchScreenKeyboard.visible)
        inputField.Select();
        if(coins!=null)
        coins.text = PlayerPrefs.GetInt("currCoins").ToString();
        if (time != null && !start) time.text = "10";
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
            if(!bonus)
            PlayerPrefs.SetInt("currCoins", PlayerPrefs.GetInt("currCoins") + 10);
            else PlayerPrefs.SetInt("currCoins", PlayerPrefs.GetInt("currCoins") + 1);
            typeSpeed += 1;
                Instantiate(platform, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0, 0, 0));
                //Instantiate(correctEffect, new Vector3(alp[l].transform.position.x, alp[l].transform.position.y, alp[l].transform.position.z), Quaternion.Euler(0, 0, 0));
                toPosition = new Vector3(alp[l].transform.position.x, playerY, alp[l].transform.position.z);
                if (k < maxK) k += 1;
                if (l > 0) l -= 1;
                inputField.text = "";
            }
            else
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
            string lang = PlayerPrefs.GetString("_language", "ru");
            if (lang == "ru")
            {
                firstFinished = true;
                typeSpeed = typeSpeed / timeInGame;
                PlayerPrefs.SetInt("TypeCount", PlayerPrefs.GetInt("TypeCount") + 1);
                PlayerPrefs.SetFloat("TypeSpeed", (PlayerPrefs.GetFloat("TypeSpeed") + typeSpeed * 60) / PlayerPrefs.GetInt("TypeCount"));
                PlayerPrefs.SetInt("currLevelRu", PlayerPrefs.GetInt("currLevelRu") + 1);
                PlayerPrefs.SetInt("levelNumRu", PlayerPrefs.GetInt("levelNumRu") + 1);
                PlayerPrefs.SetInt("Win", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("MenuEndlevel", LoadSceneMode.Single);
            }
            else
            {
                firstFinished = true;
                typeSpeed = typeSpeed / timeInGame;
                PlayerPrefs.SetInt("TypeCount", PlayerPrefs.GetInt("TypeCount") + 1);
                PlayerPrefs.SetFloat("TypeSpeed", (PlayerPrefs.GetFloat("TypeSpeed") + typeSpeed * 60) / PlayerPrefs.GetInt("TypeCount"));
                PlayerPrefs.SetInt("currLevelEng", PlayerPrefs.GetInt("currLevelEng") + 1);
                PlayerPrefs.SetInt("levelNumEng", PlayerPrefs.GetInt("levelNumEng") + 1);
                PlayerPrefs.SetInt("Win", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("MenuEndlevel", LoadSceneMode.Single);
            }
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
