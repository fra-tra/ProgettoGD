using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelDoor : MonoBehaviour
{
    private bool _memoryTaken;
    private Counter _myCounter;

    [SerializeField] public Memory _myMemory;
    [SerializeField] public bool _isHubZero;
    [SerializeField] public bool _isFinalHub;
    [SerializeField] public LevelLoader _levelLoader;

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
        if (other.tag == "Player")
        {
            ExitLevel();
        }
    }

    public void ExitLevel() //(Chiamata on trigger enter)
    {
        _memoryTaken = _myMemory.IsTaken();

        if (_isHubZero)
        {
            _myCounter._takenMemoryZero = true;
            _levelLoader.LoadNextLevel();//chiama il level loader
        }

        if (_isFinalHub)
        {
            _myCounter._takenMemoryFour = true;
            _levelLoader.LoadNext(); //chiama il level loader verso la scena finale
        }
        
        if (_memoryTaken)
        {
            _myCounter.UpdateCounter(); //incrementa il contatore del num. ricordi in counter
            _levelLoader.LoadNextLevel();//chiama il level loader
            //Play della scena giusta Ricordo_x per ogni livello
        }
    }

}
