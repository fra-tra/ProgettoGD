using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    private Counter _myCounter;
    private bool _notPressed = true;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] AudioSource feedbackKey;

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    { 
        if (other.tag == "Player")
        {
            if ( _myCounter.GetSecondObject() == 2 && Input.GetButton("SpecialObject") && _notPressed)
            {
                Debug.Log("Chiama il loader INTERNO");
                feedbackKey.Play();
                _notPressed = false;
                _levelLoader.LoadLevelFromThis(1);
            }
        }
    }

}
