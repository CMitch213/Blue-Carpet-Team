using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    //When you press "New Game"
    public void PlayGame()
    {
        Debug.Log("Loading Level 1");
        SceneManager.LoadScene("Level1");
    }

    //When you press "Settings" 
    public void Settings()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    //When you press "Quit"
    public void CloseGame()
    {
        Debug.Log("Closing Game");
        Application.Quit();
    }
}
