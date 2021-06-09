using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjectsFirstChoice : MonoBehaviour
{
    [SerializeField] public Rigidbody _playerRigidBody; //RigidBody del player 
    [SerializeField] public GameObject _gameObjectA; //Per applicargli il glow
    [SerializeField] public GameObject _gameObjectB; 
    [SerializeField] public GameObject _gameObjectC;
    [SerializeField] public LevelLoader _levelLoader;
    [SerializeField] Material _emissionMaterialA;
    [SerializeField] Material _emissionMaterialB;
    [SerializeField] Material _emissionMaterialC;

    private bool _objA = true; //Hammer
    private bool _objB = false; //Ivy
    private bool _objC = false; // Globe

    private Material _matA;
    private Material _matB; 
    private Material _matC; 
     
    

    private float _analog;
    private bool _inputGettable = true;
    private bool _notChoosen = true;
    public Counter _myCounter;
    private Coroutine _coroutine;
    // Start is called before the first frame update
    
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));//Si trova il counter
        _matA = _gameObjectA.GetComponent<MeshRenderer> ().material; 
        _matB = _gameObjectB.GetComponent<MeshRenderer> ().material; 
        _matC = _gameObjectC.GetComponent<MeshRenderer> ().material; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
         //Blocca la caduta dell’omino rendendolo Kinematic
        _playerRigidBody.isKinematic = true;
    }

    private void OnTriggerStay(Collider other)
    {
        CheckAnalog();
        CheckChoice();
    }

    //Metti una coroutine con uno Yield così se è sempre premuto l’analogico non cambaia 993772 milioni di volte
    

    private void CheckAnalog()
    {
        _analog = Input.GetAxisRaw("ChooseAxis"); //Si prende sia il joystick che A e D

        if (_analog !=0  && _inputGettable)
        {
            if(_analog <= -0.5 || _analog >= 0.5)
            {
                Debug.Log(_analog);
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

    private void MoveSelection()
    {
        //Play suono cambio scelta
        
        if (_objA)
        {
            _objA = false;

            if(_analog == 1)
            {
                _objB = true;
            }
            else
            {
                _objC = true;
            }
        }
        else if(_objB)
        {
            _objB = false;

            if(_analog == 1)
            {
                _objB = true;
            }
            else
            {
                _objA = true;
            }
        }
        else if(_objC)
        {
            _objC = false;

            if(_analog == 1)
            {
                _objA = true;
            }
            else
            { 
                _objB = true;
            }
        }
    }

    private void Glow()
    {
        if(_objA)
        { 
           _gameObjectA.GetComponent<MeshRenderer> ().material = _emissionMaterialA;
           UnGlow();
        }//Glow di oggetto A}
        else if(_objB)
        { 
           _gameObjectB.GetComponent<MeshRenderer> ().material = _emissionMaterialB;
           UnGlow();
        }//Glow di oggetto B}
        else if(_objC)
        {
           _gameObjectC.GetComponent<MeshRenderer> ().material = _emissionMaterialC;
           UnGlow();
        }//Glow di oggetto C}
    }

    private void CheckChoice()
    {
        if (Input.GetButton("SpecialObject") && _notChoosen)
        {
            //Play suono oggetto scelto
            //Scelta oggetto comunicata al counter
            _notChoosen = false;

            if (_objA)
            { 
                Debug.Log("Hammer choosen");
                _myCounter.FirstChoosenObject(1); //Hammer
            }
            else if(_objB)
            {
                Debug.Log("Ivy choosen");
                _myCounter.FirstChoosenObject(3); //ivy
            }
            else if(_objC)
            { 
                Debug.Log("Globe choosen");
                _myCounter.FirstChoosenObject(5); //Globe
            }

            ExitChoice();
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
        Debug.Log("ExitChoice");
        _coroutine = StartCoroutine(CoroutinePlayVideo());
        //Fa partire il video
        //coroutine con Yield oppure fine del fideo esplode (?)
        //LevelLoaderMannaggia
        _levelLoader.LoadNext();
    }

    public void UnGlow()
    {
        if(_objA)
        { 
           _gameObjectB.GetComponent<MeshRenderer> ().material = _matB;
           _gameObjectC.GetComponent<MeshRenderer> ().material = _matC;
        }//Glow di oggetto A}
        else if(_objB)
        { 
            _gameObjectA.GetComponent<MeshRenderer> ().material = _matA;
            _gameObjectC.GetComponent<MeshRenderer> ().material = _matC;
        }//Glow di oggetto B}
        else if(_objC)
        {
            _gameObjectA.GetComponent<MeshRenderer> ().material = _matA;
            _gameObjectB.GetComponent<MeshRenderer> ().material = _matB;
        }//Glow di oggetto C}
    }


}
