using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadIntro : MonoBehaviour
{
    [SerializeField] public GameObject _menu;
    [SerializeField] public GameObject _menuvideo; 
    [SerializeField] public GameObject _intro;
    [SerializeField] public VideoPlayer _video;
    

    private Counter _myCounter;
    private float transitionTime;

    private bool _playedIntro;

    private Coroutine _coroutine;
    void Start()
    {       
        
        
        
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _playedIntro =_myCounter.GetLogoPlayed();
       
       if(!_playedIntro)
        {
            //_menu.SetActive(false);
            //_menuvideo.SetActive(false);
            _coroutine = StartCoroutine(LoadSilly());
        }
        else
        {
            _menu.SetActive(true); 
            _menuvideo.SetActive(true);
            _video.playOnAwake = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSilly()
    {
        transitionTime = (float) _video.length; 
        yield return new WaitForSeconds(transitionTime);
        _menu.SetActive(true); 
        _menuvideo.SetActive(true);
        _intro.SetActive(false); 
        _myCounter.SetLogoPlayed(true);
        StopCoroutine(_coroutine);

    }
}
