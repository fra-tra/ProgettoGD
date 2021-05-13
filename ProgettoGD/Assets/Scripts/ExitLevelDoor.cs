using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelDoor : MonoBehaviour
{
    private bool _memoryTaken;
    private Counter _myCounter;

    [SerializeField] Memory _myMemory;

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ExitLevel();
    }

    public void ExitLevel() //(Chiamata on trigger enter)
    {
        _memoryTaken = _myMemory.IsTaken();
        
        if (_memoryTaken)
        {
            _myCounter.UpdateCounter(); //incrementa il contatore del num. ricordi in counter
            //chiama il level loder
            //Play della scena giusta Ricordo_x per ogni livello
        }
    }

}
