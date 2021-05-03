using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime=1f;

    //DA MODIFICARE PER GIOCO

    // Update is called once per frame
    void Update()
    {
        ExitGame();
    }

    //DA MODIFICARE
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    //DA MODIFICARE
    public void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 2)
        {
            End();
        }
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }

    public void End()
    {
        StartCoroutine(LoadLevel(0));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
