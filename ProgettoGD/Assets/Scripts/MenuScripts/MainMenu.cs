using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _infoMenu;
    [SerializeField] GameObject _commandsMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }


    public void DisplayInfo()
    {
        gameObject.SetActive(false);
        _infoMenu.SetActive(true);
    }

    public void DisplayCommands()
    {
        gameObject.SetActive(false);
        _commandsMenu.SetActive(true);
    }
}
