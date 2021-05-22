using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject _commandsMenu;
    [SerializeField] LevelLoader _levelLoader;
    
    public static bool GameIsPaused = false; 

    public GameObject pauseMenuUI;

    [SerializeField] public GameObject _selectedButton;
    [SerializeField] public GameObject _selectedButtonCommands;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(GameIsPaused)
           {
               Resume();
           } 
           else
           {
               Pause();
           }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); 
        Time.timeScale= 1f; 
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; 
        GameIsPaused = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_selectedButton);

    }

    public void LoadMenu()
    {
        _levelLoader.ToMenu();
        Time.timeScale= 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayCommands()
    {
        pauseMenuUI.SetActive(false);
        _commandsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_selectedButtonCommands);
    }
}
