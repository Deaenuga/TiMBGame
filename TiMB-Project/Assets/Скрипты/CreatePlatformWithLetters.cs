using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformWithLetters : MonoBehaviour
{
    public GameObject[] alphavite;
    public GameObject parentPlatform;
    public string[] letters;
    private string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
    // Start is called before the first frame update
    void Start()
    {
        float position = parentPlatform.transform.position.z-0.2f;
        for(int i = 0;i<letters.Length;i++)
        {
            for(int j=0;j<letters[i].Length;j++)
            {
                if ((letters[i][j] != ',') && (letters[i][j] != '!') && (letters[i][j] != '?') && (letters[i][j] != '.') && (letters[i][j] != '-'))
                {
                    if (letters[i][j] == ' ')
                    {
                        Instantiate(alphavite[33], new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position), Quaternion.Euler(270, 90, 180));
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
