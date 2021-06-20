using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] public VideoPlayer _video;
    [SerializeField] public GameObject _videoPanel;
    [SerializeField] bool _PlayVideoOnLoad;

    public float transitionTime = 1f;
    public Animator transition;

    private Coroutine _coroutine;

    //Contengono gli indici dell'ordine dei livelli
    private int _easy;
    private int _medium;
    private int _difficult;

    private bool _dead = false;
    private bool _lastDeath = false;
    private bool _choice = true;

    private int _nextLevel;


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

    public void LoadNext() //Funziona da menu a caduta1, da caduta1 a caduta 2 a  da caduta a hub, da hubfinale a finale
    {
        Debug.Log("Siamo nella scena" + SceneManager.GetActiveScene().buildIndex);
        _PlayVideoOnLoad = true;
        _coroutine = StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    
    public void LoadLevelFromThis (int n) //Per andare e tornare dagli interni (che sono +1 e +2 dal loro livello di riferimento)
    {
        _PlayVideoOnLoad = false;
        _coroutine = StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + n));
    }

    public void LoadNextLevel() //Funzione chiamata da Hub e dai livelli
    {
        _choice = true;
        int n = WhatNextLevel();
        Debug.Log("Next level is" + n);
       _coroutine = StartCoroutine(LoadLevel(n));
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

        if (SceneManager.GetActiveScene().buildIndex != 7)
        {
            _PlayVideoOnLoad = true;
        }

        if(_myCounter.GetEasy() && _choice) //Lo chiama l'hub
        {
            _choice = false;
            Debug.Log("To the easy level" + _easy);
            _myCounter.SetEasy(false);
            _myCounter.SetMedium(true);
            _nextLevel = _easy;
            return _easy;
        }
        else if(_myCounter.GetMedium() && _choice) //Lo chiama easy
        {
            _choice = false;
            Debug.Log("To the medium level" + _medium);
            _myCounter.SetMedium(false);
            _myCounter.SetDifficult(true);
            _nextLevel = _medium;
            return _medium;
        }
        else if(_myCounter.GetDifficult() && _choice) //Lo chiama medium
        {
            _choice = false;
            Debug.Log("To the difficult level" + _difficult);
            _myCounter.SetDifficult(false);
            _nextLevel = _difficult;
            return _difficult;
        }
        else
        {
            _nextLevel = 9;
            return 9;
        } //Valore del level loader per l'hub finale (Questa sarà chiamata dal livello difficile)
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
        StopCoroutine(_coroutine);

    }

    public void Skip(int Index) //Chiami da menu (1), da caduta1 (2) e caduta2 (3)
    {
        SceneManager.LoadScene(Index);
    }

    public void SkipPredicted() //Chiama questo quando sei in hub, livelli
    {
        SceneManager.LoadScene(_nextLevel);
    }


    public void ToMenu()
    {
        _myCounter.Reset();
        _PlayVideoOnLoad = false;
        _myCounter._returnedMenu = true;
        StartCoroutine(LoadLevel(0));
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
