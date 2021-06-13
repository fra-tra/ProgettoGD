﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Rotation: MonoBehaviour
{
    //Rotation stoppable trough gear-power

    [SerializeField] float _waitingTime = 5f;
    [SerializeField] float _rotationAngle = 360f;
    [SerializeField] float _rotationTime = 30f;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _platform;
    //[SerializeField] Rigidbody _playerRB;

    private Sequence moveSequence;
    private bool  _isPlayerOn = false;
    private bool _rotationStopped = false;
    private Coroutine _coroutine;
    private Rigidbody _playerRB;
    private Counter _myCounter;


    // Start is called before the first frame update
    void Start()
    {
        _playerRB = _player.GetComponent<Rigidbody>();
        //_myCounter = (Counter)FindObjectOfType(typeof(Counter));
        SimpleRotation();
    }

    // Update is called once per frame
    void Update()
    {
        GearPower();
    }
    
    private void GearPower()
    {
        if (_isPlayerOn && /* _myCounter.GetFirstObject() == 6 &&*/ Input.GetButton("SpecialObject"))
        {
            if (!_rotationStopped)
            {
                Debug.Log("Paused");
                moveSequence.Pause();
                _rotationStopped = true;
                _coroutine = StartCoroutine(WaitRestartRotation());

            }
        }
    }

    public IEnumerator WaitRestartRotation()
    {
        yield return new WaitForSeconds(_waitingTime);

        Debug.Log("Paused");
        moveSequence.Play();
        _rotationStopped = false;
        StopCoroutine(_coroutine);
    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            _isPlayerOn = true;
            Debug.Log(_isPlayerOn);
            _player.transform.SetParent(_platform.transform,true);
            _playerRB.isKinematic = true;
            Debug.Log("porcatroia");
        }
    }
    
    void OnTriggerStay(Collider other)
    { 
        if (other.tag == "Player")
        {
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") ||  Input.GetButton("Jump") )
                {
                    _playerRB.isKinematic = false;
                }
        }
    }
    void OnTriggerExit(Collider other)
    { 
        if (other.tag == "Player")
        {
            _isPlayerOn = false;
            _player.transform.SetParent(null);
            _playerRB.isKinematic = false;
        }
    }

    private void SimpleRotation()
    {
        Debug.Log("Rotate!");
        moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DORotate(new Vector3(0, _rotationAngle,0), _rotationTime, RotateMode.LocalAxisAdd)).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        moveSequence.Play();
    }
}
