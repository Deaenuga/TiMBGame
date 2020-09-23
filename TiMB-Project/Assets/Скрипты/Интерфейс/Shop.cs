using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public void GoToMenu() //Метод отвечающий за переход со сцены Shop на сцену Menu
    {
        SceneManager.LoadScene("Menu");

    }
}
