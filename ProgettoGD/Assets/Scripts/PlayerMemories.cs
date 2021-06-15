using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerMemories : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject _video;
    [SerializeField] GameObject _cameraPlayer;
    [SerializeField] GameObject _cameraMemory;


    //[SerializeField] public GameObject _videoPanel;
    //[SerializeField] public VideoClip _memory1;
    //[SerializeField] public VideoClip _memory2;

    private Counter _myCounter;

    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        if(_video.activeSelf)
        {
            _cameraPlayer.SetActive(false);
            _cameraMemory.SetActive(true);
        }
        
    }
}
