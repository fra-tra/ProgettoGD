using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelDoor : MonoBehaviour
{
    private bool _memoryTaken;
    [SerializeField] Memory _myMemory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitLevel() //(Chiamata on trigger enter)
    {
        _memoryTaken = _myMemory.IsTaken();
        
        if (_memoryTaken)
        {
            //incrementa il contatore in counter
            //chiama il level loder
        }
    }

}
