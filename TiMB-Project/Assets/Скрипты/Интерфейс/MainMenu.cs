using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public void PlayGame() //Метод отвечающий за переход со сцены Menu на сцену Game (расположен в объекте MainMenu)
    {
        SceneManager.LoadScene("Game");

    }

    public void QuitGame() //Метод отвечащий за выход из игры (расположен в объекте MainMenu)
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }

    public void GoToShop() //Метод отвечающий за переход со сцены Menu на сцену Shop
    {
        SceneManager.LoadScene("Shop 2");

    }

}
