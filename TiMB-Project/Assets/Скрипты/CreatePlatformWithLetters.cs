using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformWithLetters : MonoBehaviour
{
    public GameObject platform;
    public GameObject parentPlatform;
    public string[] letters;
    // Start is called before the first frame update
    void Start()
    {
        float position = parentPlatform.transform.position.z-0.6f;
        for(int i = 0;i<letters.Length;i++)
        {
            for(int j=0;j<letters[i].Length;j++)
            {
                Instantiate(platform, new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, position),parentPlatform.transform.rotation);
                position -= 1f;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
