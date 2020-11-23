using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformWithLetters : MonoBehaviour
{
    public GameObject[] alphavite;
    public GameObject parentPlatform;
    public GameObject finish;
    public string[] letters;
    private int letter;
    private string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя 1234567890.,:";
    // Start is called before the first frame update
    void Start()
    {
        letter = PlayerPrefs.GetInt("currLevel");
        findLetters();        
    }
    void findLetters()
    {
        float position = parentPlatform.transform.position.z - 0.2f;
            for (int j = 0; j < letters[letter].Length; j++)
            {
                if ((letters[letter][j] != '!') && (letters[letter][j] != '?') && (letters[letter][j] != '-'))
                {
                    //if(j==letters[letter].Length-1)
                    //Instantiate(finish, new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(0, 0, 0));
                if (letters[letter][j] == ' ')
                    {
                        Instantiate(alphavite[33], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '1')
                    {
                        Instantiate(alphavite[34], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '2')
                    {
                        Instantiate(alphavite[35], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '3')
                    {
                        Instantiate(alphavite[36], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '4')
                    {
                        Instantiate(alphavite[37], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '5')
                    {
                        Instantiate(alphavite[38], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '6')
                    {
                        Instantiate(alphavite[39], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '7')
                    {
                        Instantiate(alphavite[40], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '8')
                    {
                        Instantiate(alphavite[41], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '9')
                    {
                        Instantiate(alphavite[42], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '0')
                    {
                        Instantiate(alphavite[43], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == '.')
                    {
                        Instantiate(alphavite[44], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == ',')
                    {
                        Instantiate(alphavite[45], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[letter][j] == ':')
                    {
                        Instantiate(alphavite[46], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    {
                        int num = alph.ToUpper().IndexOf(letters[letter].ToUpper()[j]);
                        Instantiate(alphavite[num], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                }
            }

        }
    }
