﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObjectsFirstChoice : MonoBehaviour
{
    [SerializeField] public Rigidbody _playerRigidBody; //RigidBody del player 
    private float _analog;
    private bool _objA = true; //Hammer
    private bool _objB = false; //Ivy
    private bool _objC = false; // Globe
    //[SerializeField] public gameObject _gameObjectA; //Per applicargli il glow
    //[SerializeField] public gameObject _gameObjectB;
    //[SerializeField] public gameObject _gameObjectC;
    private bool _inputGettable = true;
    public Counter _myCounter;
    private Coroutine _coroutine;
    // Start is called before the first frame update
    
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));//Si trova il counter
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
        if (CheckChoice())
        {
            ExitChoice();
        }
    }

    //Metti una coroutine con uno Yield così se è sempre premuto l’analogico non cambaia 993772 milioni di volte
    

    private void CheckAnalog()
    {
        _analog = Input.GetAxis("Horizontal"); //Si prende sia il joystick che A e Da
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

        }//Glow di oggetto A}
        else if(_objB)
        { 

        }//Glow di oggetto B}
        else if(_objC)
        {

        }//Glow di oggetto C}
    }

    private bool CheckChoice()
    {
        if (Input.GetButton("SpecialObject"))
        {
            //Play suono oggetto scelto
            //Scelta oggetto comunicata al counter
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

            return true;
        }

        return false;
    }

    private void ExitChoice()
    {
        //Fa partire il video
        //coroutine con Yield oppure fine del fideo esplode (?)
        _playerRigidBody.isKinematic = false;
    }

}
