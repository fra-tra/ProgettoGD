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

    public int _currentLevel;
    public int _firstObject;
    public int _secondObject;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Counter _myCounter;
   
    void Start()
    {

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
            if(_firstObject == 1 | _secondObject == 1 ) //martello
            {
                useHammer();//Funzionamento di x
            }
            else if(_firstObject == 2 | _secondObject ==2 ) //chiave
            {
                useKey();//Funzionamento di x
            }
        }
        else if(_currentLevel == 7) //Astronomia
        {
            if(_firstObject == 5| _secondObject == 5) //globo
            {
                useGlobe();//Funzionamento di x
            }
            else if(_firstObject == 6| _secondObject == 6) //ingranaggio
            {
                useGear();//Funzionamento di x
            }
        }
        else if(_currentLevel == 6) //Commedia
        {
            if(_firstObject == 3| _secondObject == 3) //edera
            {
                useIvy();//Funzionamento di x
            }
            else if(_firstObject == 4 | _secondObject == 4) //fionda
            {
                useSling();//Funzionamento di x
            }
        }

    }

    public void useHammer()
    {
        Debug.Log("Special Object");
    }

    public void useKey()
    {
        Debug.Log("Special Object");
    }

    public void useGlobe()
    {
        Debug.Log("Special Object");
    }

    public void useGear()
    {
        Debug.Log("Special Object");
    }

    public void useIvy()
    {
        Debug.Log("Special Object");
    }

    public void useSling()
    {
        Debug.Log("Special Object");
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

}
