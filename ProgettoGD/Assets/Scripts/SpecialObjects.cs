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
    PauseGame _pauseScript;
    private bool _paused;


    private Coroutine _coroutine;
    private Counter _myCounter;
    private Statue _targetStatue;
    private StatueMemory _targetStatueMemory;
    private BreakableDoor _targetDoor;
    private bool _pressable = true;
    private bool _objectDetected = false;
    private string _objectTag;
    private Collider _target;
    Animator m_Animator;

    public static bool useObjects = false;

    [SerializeField] AudioClip keyAudioClip;
   
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        m_Animator = GetComponent<Animator>();
        _pauseScript =  (PauseGame)FindObjectOfType(typeof(PauseGame));
    }

    // Update is called once per frame
    void Update()
    {
        SpecialObjPressed();
    }

    public void SpecialObjPressed()
    {
        _paused = _pauseScript.GetPaused();

        if (Input.GetButton("SpecialObject") ) //se il tasto del joypad o della tastiera è stato premuto 
        {
            if(_pressable && !_paused)
            {
                Debug.Log("Got button");
                _pressable = false;
                useObjects = true;
                _coroutine = StartCoroutine(UseSpecialObject());
            }
        }
        else if(Input.GetButton("SpecialObjectTwo") )
        {
            if(_pressable && !_paused)
            {
                Debug.Log("Got button");
                _pressable = false;
                useObjects = true;
                _coroutine = StartCoroutine(UseSpecialObjectTwo());
            }
        }
    }

    public IEnumerator UseSpecialObject()
    {
        _currentLevel = _levelLoader.CurrentLevel();
        _firstObject = _myCounter.GetFirstObject();
        _secondObject = _myCounter.GetSecondObject();

        
            if(_firstObject == 1) //martello
            {
                useHammer();//Funzionamento di x
            }
            else if(_secondObject ==2) //chiave
            {
                useKey();//Funzionamento di x
            }
        
        yield return new WaitForSeconds(0.5f);
        _pressable = true;
        Debug.Log("Dopo Yield coroutine use object");
        StopCoroutine(_coroutine);

    }

    public IEnumerator UseSpecialObjectTwo()
    {
        _firstObject = _myCounter.GetFirstObject();
        _secondObject = _myCounter.GetSecondObject();

        if(_firstObject == 5) //globo
        {
            useGlobe();//Funzionamento di globe
        }
        else if(_secondObject == 6) //ingranaggio
        {
            useGear();//Funzionamento di gear
        }
        
        yield return new WaitForSeconds(0.5f);
        _pressable = true;
        Debug.Log("Dopo Yield coroutine use object");
        StopCoroutine(_coroutine);

    }


    
    public void useHammer()
    {
        Debug.Log("Special Object Hammer");

        //ANIMAZIONE CHIAMATA COMUNQUE
        m_Animator.SetTrigger("useHammer");
        useObjects = false;
        _currentLevel = _levelLoader.CurrentLevel();
        
        if(_currentLevel == 4 && _objectDetected)
        {
            _objectDetected = false;
            Debug.Log("Inside hammer distance");
            
            if (_target.gameObject.activeInHierarchy)
            {
                if (_objectTag == "BreakableDoor")
                {
                    _targetDoor = (BreakableDoor)_target.GetComponentInParent(typeof(BreakableDoor)); //Se non funziona prova GetComponent
                    if(!_targetDoor.GetOpenDoor())
                    {
                        _targetDoor.hitHammer();
                    }
                    //_targetDoor.hitHammer();
                }
                else if (_objectTag == "BreakableStatue")
                {
                    Debug.Log("Inside breakable statue");
                    _targetStatue = (Statue)_target.GetComponentInParent(typeof(Statue)); //Se non funziona prova GetComponent
                    _targetStatue.hitHammer();
                }
                else if(_objectTag == "StatueMemory")
                {
                    _targetStatueMemory = (StatueMemory)_target.GetComponentInParent(typeof(StatueMemory)); //Se non funziona prova GetComponent
                    _targetStatueMemory.hitHammer();

                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        _objectDetected = true;
        _objectTag = other.tag;
        _target = other;
        Debug.Log(_objectTag);
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

        m_Animator.SetTrigger("useKey");
        useObjects = false;
        
        //AudioSource.PlayClipAtPoint(keyAudioClip, transform.position);

    }

    public void useGlobe()
    {
        Debug.Log("Special Object Globe");
         m_Animator.SetTrigger("useGlobe");
        //ANIMAZIONE CHIAMATA COMUNQUE

    }

    public void useGear()
    {
        Debug.Log("Special Object Gear");
         m_Animator.SetTrigger("useGear");
        //ANIMAZIONE CHIAMATA COMUNQUE


    }

    public void useIvy()
    {
        Debug.Log("Special Object Ivy");
        //ANIMAZIONE CHIAMATA COMUNQUE


    }

    public void useSling()
    {
        Debug.Log("Special Object Sling");
        //ANIMAZIONE CHIAMATA COMUNQUE


    }

}
