using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAstronomy : MonoBehaviour
{
    [SerializeField] LevelLoader _levelLoader;
    [SerializeField] Memory _mem;
    private Counter _myCounter;
    private bool _loaded = false;
    
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {

        if(_mem.IsTaken() && !_loaded)
        {
            _loaded = true;
            Debug.Log("RICORDO PRESO");
            _myCounter.UpdateCounter();
            _levelLoader.LoadNextLevel();
        }
    }
}
