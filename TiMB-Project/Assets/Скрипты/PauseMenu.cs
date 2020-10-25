using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

 

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //isClicked = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //isClicked = true;
    }

    public void GoToMenu() //Метод отвечающий за переход со сцены Shop на сцену Menu
    {
        Time.timeScale = 1f;
        Invoke("GoToMenuInvoke", 0.5f);
    }

    void GoToMenuInvoke()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Invoke("QuitGameInvoke", 0.5f);
        
    }

    void QuitGameInvoke()
    {
        Debug.Log("Выходим из игры");
        Application.Quit();
    }
}
