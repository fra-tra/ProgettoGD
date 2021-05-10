using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime=1f;
    private int _easy;
    private int _medium;
    private int _difficult;
    private bool _easyLevel = true;
    private bool _mediumLevel = false;
    private bool _difficultLevel = true;
    private bool _dead = false;

    public int CurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex ;
    }

    public void LoadNext() //Funziona da menu a caduta, da caduta a hub, da hubfinale a finale
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    
    public void LoadLevelFromThis (int n) //Per andare e tornare dagli interni (che sono +1 e +2 dal loro livello di riferimento)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + n));
    }

    public void LoadNextLevel() //Funzione chiamata da Hub e dai livelli
    {
        StartCoroutine( LoadLevel(WhatNextLevel()) );
    }

    public void SetLevelOrder(int f, int m, int d)
    {
        _easy = f;
        _medium = m;
        _difficult = d;
    }

    public int WhatNextLevel()
    {
        if(_dead)
        {
            _dead = false;
            return (SceneManager.GetActiveScene().buildIndex);
        }

        if(_easyLevel)
        {
            _easyLevel = false;
            _mediumLevel = true;
            return _easy;
        }
        else if(_mediumLevel)
        {
            _mediumLevel = false;
            _difficultLevel = true;
            return _medium;
        }
        else if(_difficultLevel)
        {
            _difficultLevel = false;
            return _difficult;
        }
        else return 6; //Valore del level loader per l'hub finale (Questa sarà chiamata dal livello difficile)
    }

    public void Death()
    {
        _dead = true;
    }

    //DA MODIFICARE
   /* public void ExitGame()
    {
        if (condizione di  uscita)
        {
            ToMenu();
        }
    } */

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }

    public void ToMenu()
    {
        StartCoroutine(LoadLevel(0));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
