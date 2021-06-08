using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Example_path : MonoBehaviour
{
    [SerializeField] float _waitingTime=5f;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _platform;

    private Sequence moveSequence;
    private bool  _isPlayerOn = false;
    private bool _rotationStopped = false;
    private Coroutine _coroutine;
    private Rigidbody _playerRB;
    private bool _isGrounded = false;

    [SerializeField] private Transform _waypointsRoot;
    [SerializeField] private float _pathDuration;


    // Start is called before the first frame update
    void Start()
    {
        //_trueplatform.transform.SetParent(_platform.transform,true);

        _playerRB = _player.GetComponent<Rigidbody>();
        MoveAlongPath();
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
        }
    }
    
    void OnTriggerStay(Collider other)
    { 
        if (other.tag == "Player")
        {
            //if (_isGrounded)
            //{
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") ||  Input.GetButton("Jump") )
                {
                    _playerRB.isKinematic = false;
                }
            //}
        }
    }

    /*void OnCollisionStay(Collision collision)
    {
        _isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }*/

    void OnTriggerExit(Collider other)
    { 
        if (other.tag == "Player")
        {
            _isPlayerOn = false;
            _player.transform.SetParent(null);
            _playerRB.isKinematic = false;
        }
    }

    /*private void SimpleRotation() //Levo giuro
    {
        Debug.Log("Rotate!");
        moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DORotate(new Vector3(0, _rotationAngle,0), _rotationTime, RotateMode.LocalAxisAdd)).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        moveSequence.Play();
    }*/


    private void MoveAlongPath()
    {
        if (_waypointsRoot != null && _waypointsRoot.childCount > 0)
        {
            Vector3[] pathPositions = new Vector3[_waypointsRoot.childCount];
            for (int i = 0; i < _waypointsRoot.childCount; i++)
                pathPositions[i] = _waypointsRoot.GetChild(i).position;

            moveSequence = DOTween.Sequence();
            moveSequence.Append( transform.DOPath(pathPositions, _pathDuration, PathType.CatmullRom, PathMode.Full3D, resolution: 10, Color.yellow) ).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
            moveSequence.Play();
        } 
    }
}
