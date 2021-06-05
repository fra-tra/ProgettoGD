using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Rotation_GearCommanded : MonoBehaviour
{
    [SerializeField] float _rotationTime = 5f;
    [SerializeField] float  _rotationAngle = 360;
    [SerializeField] float _waitingTime=5f;
    [SerializeField] Transform playerTransform;

    private Sequence moveSequence;
    private bool  _isPlayerOn = false;
    private bool _rotationStopped = false;
    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        SimpleRotation();
    }

    // Update is called once per frame
    void Update()
    {
        GearPower();
        PlayerOn();
    }

    private void PlayerOn()
    {
        if ( _isPlayerOn)
        {
            //splayerTransform.position = Vector3.MoveTowards(playerTransform.position, destination, Time.deltaTime * movingSpeed);
        }
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



    void OnCollisionEnter(Collision collision)
    { 
        if (collision.collider.name == "Player")
        {
            _isPlayerOn = true;
        }
    }
    
    void OnCollisionExit(Collision collision)
    { 
        if (collision.collider.name == "Player")
        {
            _isPlayerOn = false;
        }
    }

    private void SimpleRotation() //MOVIMENTO ASSI
    {
        Debug.Log("Rotate!");
        moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DORotate(new Vector3(0, _rotationAngle,0), _rotationTime, RotateMode.LocalAxisAdd)).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        moveSequence.Play();
    }
}
