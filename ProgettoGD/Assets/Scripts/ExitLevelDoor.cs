using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelDoor : MonoBehaviour
{
    private bool _memoryTaken;
    private Counter _myCounter;
    private bool _entered = false;

    [SerializeField] public Memory _myMemory;
    [SerializeField] public bool _isHubZero;
    [SerializeField] public bool _isFinalHub;
    [SerializeField] public LevelLoader _levelLoader;

    private Rigidbody _rb;

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
        if (other.tag == "Player" && !_entered)
        {
            _entered = true;
            _rb = other.gameObject.GetComponent<Rigidbody>();
        
            ExitLevel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && _entered)
        {
            _entered = false;
        }
    }

    public void ExitLevel() //(Chiamata on trigger enter)
    {
        _memoryTaken = _myMemory.IsTaken();
        

        if (_isHubZero && _memoryTaken && _myCounter.GetEasy())
        {
            _myCounter._takenMemoryZero = true;
            _rb.isKinematic = true;
            _levelLoader.LoadNextLevel();//chiama il level loader
        }
        else if (_isFinalHub)
        {
            _myCounter._takenMemoryFour = true;
            _rb.isKinematic = true;
            _levelLoader.LoadNext(); //chiama il level loader verso la scena finale
        }
        else if (_memoryTaken && !_isHubZero)
        {
            Debug.Log("lOADING MEMORY TAKEN");
            _rb.isKinematic = true;
            _myCounter.UpdateCounter(); //incrementa il contatore del num. ricordi in counter
            _levelLoader.LoadNextLevel();//chiama il level loader
            //Play della scena giusta Ricordo_x per ogni livello
        }
    }

}
