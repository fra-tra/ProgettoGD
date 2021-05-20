using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjects : MonoBehaviour
{
    // Start is called before the first frame update

    // Interi riferiti all'oggetto speciale
    //hammer 1
    //key 2
    //ivy 3
    //sling 4
    //globe 5
    //gear 6

    //Questo script viene attaccato al Third Person Controller

    public int _currentLevel;
    public int _firstObject;
    public int _secondObject;

    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private int _hammerDistance;
    [SerializeField] private int _keyDistance;

    private Counter _myCounter;
    private Statue _targetStatue;
    private BreakableDoor _targetDoor;
    private bool _pressable = true;
    private bool _objectDetected = false;
    private string _objectTag;
    private Collider _target;
   
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        xPressed();
    }

    public void xPressed()
    {
        if (Input.GetButton("SpecialObject") && _pressable)//se il tasto del joypad o della tastiera è stato premuto 
        {
            Debug.Log("Got button");
            _pressable = false;
            //Prova se il bottone funziona dal manager dei bottoni (??)
            //UseSpecialObject();
            useHammer();
        }
    }

    public void UseSpecialObject()
    {
        _currentLevel = _levelLoader.CurrentLevel();
        _firstObject = _myCounter.GetFirstObject();
        _secondObject = _myCounter.GetSecondObject();

        if( _currentLevel == 3) //Poesia Epica
        {
            if(_firstObject == 1) //martello
            {
                useHammer();//Funzionamento di x
            }
            else if(_secondObject ==2) //chiave
            {
                useKey();//Funzionamento di x
            }
        }
        else if(_currentLevel == 7) //Astronomia
        {
            if(_firstObject == 5) //globo
            {
                useGlobe();//Funzionamento di x
            }
            else if(_secondObject == 6) //ingranaggio
            {
                useGear();//Funzionamento di x
            }
        }
        else if(_currentLevel == 6) //Commedia
        {
            if(_firstObject == 3) //edera
            {
                useIvy();//Funzionamento di x
            }
            else if(_secondObject == 4) //fionda
            {
                useSling();//Funzionamento di x
            }
        }

    }

    public void useHammer()
    {
        Debug.Log("Special Object Hammer");

        //ANIMAZIONE CHIAMATA COMUNQUE
        
        if(_objectDetected)
        {
            _objectDetected = false;
            Debug.Log("Inside hammer distance");
            
            if (_objectTag == "BreakableDoor")
            {
                _targetDoor = (BreakableDoor)_target.GetComponentInParent(typeof(BreakableDoor)); //Se non funziona prova GetComponent
                _targetDoor.hitHammer();
            }
            else if (_objectTag == "BreakableStatue")
            {
                Debug.Log("Inside breakable statue");
                _targetStatue = (Statue)_target.GetComponentInParent(typeof(Statue)); //Se non funziona prova GetComponent
                _targetStatue.hitHammer();
            }
        }
         _pressable = true;
    }

     private void OnTriggerEnter(Collider other)
    {
        _objectDetected = true;
        _objectTag = other.tag;
        _target = other;
    }

    private void OnTriggerExit(Collider other)
    {
        _objectDetected = false;
        _objectTag = "";
    }

    public void useKey()
    {
        Debug.Log("Special Object Key");
        //ANIMAZIONE CHIAMATA COMUNQUE
        //Ray ray = new Ray (this.transform.position, Vector3.forward);
        //RaycastHit hit;
        
        if( _objectDetected)
        {            
            if (_objectTag == "KeyDoor")
            {
                
                //Chiama il level loader che "Apre direttamente la porta e sticazzi è più veloce così senza fare la classe
                _levelLoader.LoadLevelFromThis(1); //C'è un 1 perché progressivamente l'interno 1 è un +1 dal livello in cui è
            }
        }
        _pressable = true;

    }

    public void useGlobe()
    {
        Debug.Log("Special Object Globe");
        //ANIMAZIONE CHIAMATA COMUNQUE
        _pressable = true;

    }

    public void useGear()
    {
        Debug.Log("Special Object Gear");
        //ANIMAZIONE CHIAMATA COMUNQUE
        _pressable = true;

    }

    public void useIvy()
    {
        Debug.Log("Special Object Ivy");
        //ANIMAZIONE CHIAMATA COMUNQUE
        _pressable = true;

    }

    public void useSling()
    {
        Debug.Log("Special Object Sling");
        //ANIMAZIONE CHIAMATA COMUNQUE
        _pressable = true;

    }


}
