using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformWithLetters : MonoBehaviour
{
    public GameObject[] alphavite;
    public GameObject parentPlatform;
    public string[] letters;
    private string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя 1234567890.,:";
    // Start is called before the first frame update
    void Start()
    {
        findLetters();        
    }
    void findLetters()
    {
        float position = parentPlatform.transform.position.z - 0.2f;
        for (int i = 0; i < letters.Length; i++)
        {
            for (int j = 0; j < letters[i].Length; j++)
            {
                if ((letters[i][j] != '!') && (letters[i][j] != '?') && (letters[i][j] != '-'))
                {
                    if (letters[i][j] == ' ')
                    {
                        Instantiate(alphavite[33], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '1')
                    {
                        Instantiate(alphavite[34], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '2')
                    {
                        Instantiate(alphavite[35], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '3')
                    {
                        Instantiate(alphavite[36], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '4')
                    {
                        Instantiate(alphavite[37], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '5')
                    {
                        Instantiate(alphavite[38], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '6')
                    {
                        Instantiate(alphavite[39], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '7')
                    {
                        Instantiate(alphavite[40], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '8')
                    {
                        Instantiate(alphavite[41], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '9')
                    {
                        Instantiate(alphavite[42], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '0')
                    {
                        Instantiate(alphavite[43], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == '.')
                    {
                        Instantiate(alphavite[44], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == ',')
                    {
                        Instantiate(alphavite[45], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    if (letters[i][j] == ':')
                    {
                        Instantiate(alphavite[46], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                    else
                    {
                        int num = alph.ToUpper().IndexOf(letters[i].ToUpper()[j]);
                        Instantiate(alphavite[num], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
                        position -= .5f;
                    }
                }

            }
        }
    }
}
