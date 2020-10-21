using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoriesSelect : MonoBehaviour
{
    public GameObject[] accessories;
    public int curraccess;
    // Start is called before the first frame update
    void Update()
    {
        //int curraccess = PlayerPrefs.GetInt("PlayerAccess");
        for (int i = 0; i < accessories.Length; i++)
        {
            if (i == curraccess )
                accessories[i].gameObject.SetActive(true);
            else accessories[i].SetActive(false);
        }
    }
}
