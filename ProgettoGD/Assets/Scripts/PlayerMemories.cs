using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerMemories : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public VideoPlayer _video1;
    [SerializeField] public VideoPlayer _video2;

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
        if(_myCounter.GetMemoryCounter() == 1)
        {
            _video1.Play();
        }
        else if(_myCounter.GetMemoryCounter() == 2)
        {
            _video2.Play();
        }
    }
}
