using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjectsSecondChoice : MonoBehaviour
{
    [SerializeField] public Rigidbody _playerRigidBody; //RigidBody del player 
    [SerializeField] public GameObject _gameObjectA; //Key    Per applicargli il glow ed istanziarli
    [SerializeField] public GameObject _gameObjectB; // sling
    [SerializeField] public GameObject _gameObjectC; // gear
    [SerializeField] public LevelLoader _levelLoader;

    private bool _objOne = true;
    private bool _objTwo = false;
    private GameObject _One;
    private GameObject _Two;

    private float _analog;
    private bool _inputGettable = true;
    private bool _notChoosen = true;
    private bool _instantiateObjects = true;
    private Coroutine _coroutine;
    public Counter _myCounter;
    
    private int _numberOfObjOne;
    private int _numberOfObjTwo;
    private int _firstChoice;
    //hammer 1 (key 2)
    //ivy 3 (sling 4)
    //globe 5 (gear 6)

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));//Si trova il counter
    }

    // Update is called once per frame
    void Update()
    {
        ActivateCorrectObjects();        
    }

    private void  ActivateCorrectObjects()
    {
        if (_myCounter.GetFirstObject() != 0 && _instantiateObjects)
        {
            _instantiateObjects = false;

            if (_myCounter.GetFirstObject() == 1)
            {
                _gameObjectA.SetActive(false);
                _One = _gameObjectB; // sling
                _numberOfObjOne = 4;
                _Two = _gameObjectC; // gear
                _numberOfObjTwo = 6;
            }
            else if (_myCounter.GetFirstObject() == 3)
            {
                _gameObjectB.SetActive(false);
                _One = _gameObjectA; // key
                _numberOfObjOne = 2;
                _Two = _gameObjectC; // gear
                _numberOfObjTwo = 6;
            }
            else if (_myCounter.GetFirstObject() == 5)
            {
                _gameObjectC.SetActive(false);
                _One = _gameObjectA; // key
                _numberOfObjOne = 2;
                _Two = _gameObjectB; // sling
                _numberOfObjTwo = 4;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         //Blocca la caduta dell’omino rendendolo Kinematic
        _playerRigidBody.isKinematic = true;
       _firstChoice = _myCounter.GetFirstObject();
    }

    private void OnTriggerStay(Collider other)
    {
        CheckAnalog();
        if (CheckChoice())
        {
            ExitChoice();
        }
    }

    private void CheckAnalog()
    {
        _analog = Input.GetAxisRaw("Horizontal"); //Si prende sia il joystick che A e Da
        if (_analog != 0 && _inputGettable)
        {
            Debug.Log("Change choice");
            _inputGettable = false;
            MoveSelection();
            Glow();
            _coroutine = StartCoroutine(CoroutineWaitForChange());//Chiamata a coroutine che aspetta un tot e poi reimposta_inputGettable=true;
        }
    }

    public IEnumerator CoroutineWaitForChange()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("After Yield");
        _inputGettable  = true;
        StopCoroutine(_coroutine);
    }

    private void Glow()
    {
        if(_objOne)
        { 
            //Glow _One
        }
        else if(_objTwo)
        { 
            //Glow _Two
        }
    }

    private bool CheckChoice()
    {
        if (Input.GetButton("SpecialObject") && _notChoosen)
        {
            _notChoosen = false;
            //Play suono oggetto scelto
            //Scelta oggetto comunicata al counter
            if (_objOne)
            { 
                Debug.Log("One choosen");
                _myCounter.SecondChoosenObject(_numberOfObjOne); // key
            }
            else if(_objTwo)
            {
                Debug.Log("Two choosen");
                _myCounter.SecondChoosenObject(_numberOfObjTwo); // sling
            }

            return true;
        }

        return false;
    }

    private void MoveSelection()
    {
        //Play suono cambio scelta
        
        if (_objOne)
        {
            _objOne = false;
            _objTwo = true;
        }
        else if(_objTwo)
        {
            _objTwo = false;
            _objOne = true;
        }
    }

    public IEnumerator CoroutinePlayVideo()
    {
        //PLAY VIDEO
        yield return new WaitForSeconds(0.3f); //Da cambiare valore
        Debug.Log("After Yield Video");
        StopCoroutine(_coroutine);
    }

    private void ExitChoice()
    {
        _coroutine = StartCoroutine(CoroutinePlayVideo());//Fa partire il video di scelta oggetto e atterraggio nell'hub
        _levelLoader.LoadNext(); //Level loader
    }
}
