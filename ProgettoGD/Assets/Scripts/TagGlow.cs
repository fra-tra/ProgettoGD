using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagGlow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject _tagObjectA; //Hammer
    [SerializeField] public GameObject _tagObjectB; //key
    [SerializeField] public GameObject _tagObjectC; //Globe
    [SerializeField] public GameObject _tagObjectD; //Gear

    //Material for glowing tag
    [SerializeField] Material _glowA;
    [SerializeField] Material _glowB;
    [SerializeField] Material _glowC;
    [SerializeField] Material _glowD;

    [SerializeField] public LevelLoader _levelLoader;

    public int _currentLevel;
    public int _firstObject;
    public int _secondObject;
    private Counter _myCounter;


    void Start()
    {
         _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        glowTag();
    }


    public void glowTag()
    {
        _currentLevel = _levelLoader.CurrentLevel();
        _firstObject = _myCounter.GetFirstObject();
        _secondObject = _myCounter.GetSecondObject();

        if( _currentLevel == 3) //Poesia Epica
        {
            if(_firstObject == 1) //martello
            {
                glowHammer();//Funzionamento di x
            }
            else if(_secondObject ==2) //chiave
            {
                glowKey();//Funzionamento di x
            }
        }
        else if(_currentLevel == 7) //Astronomia
        {
            if(_firstObject == 5) //globo
            {
                glowGlobe();//Funzionamento di x
            }
            else if(_secondObject == 6) //ingranaggio
            {
                glowGear();//Funzionamento di x
            }
        }
    }

    public void glowHammer()
    {
        _tagObjectA.GetComponent<MeshRenderer> ().material = _glowA;
    }

    public void glowKey()
    {
        _tagObjectB.GetComponent<MeshRenderer> ().material = _glowB;
    }

    public void glowGlobe()
    {
        _tagObjectC.GetComponent<MeshRenderer> ().material = _glowC;
    }

    public void glowGear()
    {
        _tagObjectD.GetComponent<MeshRenderer> ().material = _glowD;
    }
}
