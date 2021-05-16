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
    //[SerializeField] private float _minDistanceHammer;

    private Counter _myCounter;
   
    void Start()
    {
         _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        xPressed();
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
       /* if (IsTargetWithinDistance(_minDistanceHammer))
        {
            
        }*/

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            var floortag = hit.collider.gameObject.tag;
        }

    }

    public void useKey()
    {
        Debug.Log("Special Object Key");
    }

    public void useGlobe()
    {
        Debug.Log("Special Object Globe");
    }

    public void useGear()
    {
        Debug.Log("Special Object Gear");
    }

    public void useIvy()
    {
        Debug.Log("Special Object Ivy");
    }

    public void useSling()
    {
        Debug.Log("Special Object Sling");
    }


    public void xPressed()
    {
        if (Input.GetButton("SpecialObject") )//se il tasto del joypad o della tastiera è stato premuto 
        {
            Debug.Log("Got button");
            //Prova se il bottone funziona dal manager dei bottoni (??)
            UseSpecialObject();
        }
    }

    /*private bool IsTargetWithinDistance(float distance)
    {
        return (_target.transform.position - transform.position).sqrMagnitude <= distance * distance;
    }*/

}
