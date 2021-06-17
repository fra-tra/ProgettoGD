using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _infoMenu;
    [SerializeField] GameObject _commandsMenu;
    [SerializeField] GameObject _mainMenu;
    [SerializeField] public GameObject _selectedButtonControls;
    [SerializeField] public GameObject _selectedButtonInfo;
    [SerializeField] LevelLoader _levelLoader;


    public void PlayGame()
    {
        _mainMenu.SetActive(false);
        _levelLoader.LoadNext();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
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

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_selectedButtonInfo);
    }

    public void DisplayCommands()
    {
        gameObject.SetActive(false);
        _commandsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_selectedButtonControls);
    }
}
