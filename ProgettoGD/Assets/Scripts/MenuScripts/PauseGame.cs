using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject _commandsMenu;
    [SerializeField] LevelLoader _levelLoader;
    [SerializeField] public GameObject _videoPanel;
    
    public static bool GameIsPaused = false; 

    public GameObject pauseMenuUI;
    public Rigidbody _rb;

    [SerializeField] public GameObject _selectedButton;
    [SerializeField] public GameObject _selectedButtonCommands;

    void Update()
    {
        if(!_videoPanel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 9"))
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

    }

    public bool GetPaused()
    {
        return GameIsPaused;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _rb.isKinematic = false;
        pauseMenuUI.SetActive(false); 
        Time.timeScale= 1f; 
        GameIsPaused = false;
        
    }

    void Pause()
    {
        _rb.isKinematic = true;
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
        GameIsPaused = false;
        _rb.isKinematic = false;
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
