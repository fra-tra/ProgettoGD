using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAstronomy : Memory
{
    [SerializeField] LevelLoader _levelLoader;
    private Counter _myCounter;
    
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTaken())
        {
             _myCounter.UpdateCounter();
            _levelLoader.LoadNextLevel();
        }
    }
}
