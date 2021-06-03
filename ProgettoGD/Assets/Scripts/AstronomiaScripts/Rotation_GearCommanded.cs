using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Rotation_GearCommanded : MonoBehaviour
{
    [SerializeField] float _rotationTime = 5f;
    [SerializeField] float  _rotationAngle = 360;
    private Sequence moveSequence;
    private bool  _isPlayerOn = false;
    private bool _rotationStopped = false;
    // Start is called before the first frame update
    void Start()
    {
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
            if (_rotationStopped)
            {
                Debug.Log("Paused");
                moveSequence.Play();
                _rotationStopped = false;
            }
            else
            {
                Debug.Log("Paused");
                moveSequence.Pause();
                _rotationStopped = true;
            }
        }
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
