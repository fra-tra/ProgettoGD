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
    [SerializeField] Material _emissionMaterialA;
    [SerializeField] Material _emissionMaterialB;
    [SerializeField] Material _emissionMaterialC;

    [SerializeField] AudioSource _audioWind;

    private bool _objOne = true;
    private bool _objTwo = false;
    private GameObject _One;
    private GameObject _Two;
    private Material _matOne;
    private Material _matTwo;
    private Material _emissionOne;
    private Material _emissionTwo;



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
                _matOne = _gameObjectB.GetComponent<MeshRenderer> ().material;
                _emissionOne = _emissionMaterialB;

                _Two = _gameObjectC; // gear
                _numberOfObjTwo = 6;
                _matTwo= _gameObjectC.GetComponent<MeshRenderer> ().material;
                _emissionTwo = _emissionMaterialC;
            }
            else if (_myCounter.GetFirstObject() == 3)
            {
                _gameObjectB.SetActive(false);

                _One = _gameObjectA; // key
                _numberOfObjOne = 2;
                _matOne= _gameObjectA.GetComponent<MeshRenderer> ().material;
                _emissionOne = _emissionMaterialA;

                _Two = _gameObjectC; // gear
                _numberOfObjTwo = 6;
                _matTwo= _gameObjectC.GetComponent<MeshRenderer> ().material;
                _emissionTwo = _emissionMaterialC;
            }
            else if (_myCounter.GetFirstObject() == 5)
            {
                _gameObjectC.SetActive(false);

                _One = _gameObjectA; // key
                _numberOfObjOne = 2;
                _matOne= _gameObjectA.GetComponent<MeshRenderer> ().material;
                _emissionOne = _emissionMaterialA;

                _Two = _gameObjectB; // sling
                _numberOfObjTwo = 4;
                _matTwo= _gameObjectB.GetComponent<MeshRenderer> ().material;
                _emissionTwo = _emissionMaterialB;
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
        CheckChoice();
    }

    private void CheckAnalog()
    {
        _analog = Input.GetAxisRaw("ChooseAxis"); //Si prende sia il joystick che A e Da
        if (_analog != 0 && _inputGettable)
        {
            if(_analog <= -0.5 || _analog >= 0.5)
            {
                Debug.Log("Change choice");
                _inputGettable = false;
                MoveSelection();
                Glow();
                _coroutine = StartCoroutine(CoroutineWaitForChange());//Chiamata a coroutine che aspetta un tot e poi reimposta_inputGettable=true;
            }
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
            _One.GetComponent<MeshRenderer> ().material = _emissionOne;
            UnGlow();
        }
        else if(_objTwo)
        { 
            //Glow _Two
            _Two.GetComponent<MeshRenderer> ().material = _emissionTwo;
            UnGlow();
        }
    }

    private void CheckChoice()
    {
        if (Input.GetButton("SpecialObject") && _notChoosen)
        {
            _notChoosen = false;
            //Play suono oggetto scelto
            //Scelta oggetto comunicata al counter
            if (_objOne)
            { 
                Debug.Log("One choosen" + _numberOfObjOne);

                _myCounter.SecondChoosenObject(_numberOfObjOne);
            }
            else if(_objTwo)
            {
                Debug.Log("Two choosen" + _numberOfObjTwo);
                _myCounter.SecondChoosenObject(_numberOfObjTwo);
            }

            //return true;
            ExitChoice();
        }
        
        //return false;
    }

    private void MoveSelection()
    {
        //Play suono cambio scelta
         if (_notChoosen)
        {
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
        _audioWind.mute();
        _coroutine = StartCoroutine(CoroutinePlayVideo());//Fa partire il video di scelta oggetto e atterraggio nell'hub
        _levelLoader.LoadNext(); //Level loader
    }


    private void UnGlow()
    {
        if(_objOne)
        { 
            //UnGlow _Two
            _Two.GetComponent<MeshRenderer> ().material = _matTwo;
        }
        else if(_objTwo)
        { 
            //UnGlow _One
            _One.GetComponent<MeshRenderer> ().material = _matOne;
        }
    }
    
    
}
