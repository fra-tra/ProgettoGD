using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intern1Manager : MonoBehaviour
{
    private Counter _myCounter;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _position;
    [SerializeField] private LevelLoader _levelLoader;

    // Start is called before the first frame update
    void Start()
    {

        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _myCounter.SetIntern1(true); //Deve essere settato a false appena ricarichi la montagna, ma dopo che lo controlli

        if (_myCounter.GetSecondObject() == 2 )
        {
            _player.transform.position = _position.transform.position; //Sposta la transform del player davanti la porta giusta
           
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _levelLoader.LoadLevelFromThis(-1);
            Debug.Log("yey");

        }
        
    }
    
}
