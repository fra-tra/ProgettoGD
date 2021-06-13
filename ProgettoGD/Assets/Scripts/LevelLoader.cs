using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public VideoPlayer _video;
    [SerializeField] public GameObject _videoPanel;

    public float transitionTime = 1f;
    public Animator transition;
    private int _easy;
    private int _medium;
    private int _difficult;
    private bool _easyLevel = true;
    private bool _mediumLevel = false;
    private bool _difficultLevel = false;
    private bool _dead = false;
    private bool _lastDeath = false;
    private bool _PlayVideoOnLoad = true;

    private Counter _myCounter;

     void Start()
     {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _easy = _myCounter.easy;
        _medium = _myCounter.medium;
        _difficult = _myCounter.difficult;
     }

    public int CurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex ;
    }

    public void LoadNext() //Funziona da menu a caduta, da caduta a hub, da hubfinale a finale
    {
        _PlayVideoOnLoad = true;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    
    public void LoadLevelFromThis (int n) //Per andare e tornare dagli interni (che sono +1 e +2 dal loro livello di riferimento)
    {
         _PlayVideoOnLoad = false;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + n));
    }

    public void LoadNextLevel() //Funzione chiamata da Hub e dai livelli
    {
        StartCoroutine( LoadLevel(WhatNextLevel()) );
    }

    public int WhatNextLevel()
    {
        if(_dead)
        {
            _dead = false;
            _PlayVideoOnLoad = false;
            return (SceneManager.GetActiveScene().buildIndex);
        }
        else if (_lastDeath)
        {
            _lastDeath = false;
            _PlayVideoOnLoad = false;
            return 3; //Numero dell'hub iniziale perché sei morto del tutto
        }

        _PlayVideoOnLoad = true;

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
        else return 9; //Valore del level loader per l'hub finale (Questa sarà chiamata dal livello difficile)
    }

    public void Death()
    {
        _dead = true;
    }

    public void LastDeath()
    {
        _lastDeath = true;
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        if (_PlayVideoOnLoad)
        {
            _videoPanel.SetActive(true);
            _video.playOnAwake = false;

            _video.Play();
            transitionTime = (float) _video.length;
            yield return new WaitForSeconds(transitionTime + 0.1f);
        }
        else
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
        }

        SceneManager.LoadScene(levelIndex);

    }

    public void ToMenu()
    {
        StartCoroutine(LoadLevel(0));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
