using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotationYoYo : MonoBehaviour
{
    [SerializeField] float _rotationTime = 5f;
    [SerializeField] float  _rotationAngle = 30;
     private Sequence moveSequence;
    // Start is called before the first frame update
    void Start()
    {
        YoYoRotation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void YoYoRotation() //MOVIMENTO ASSI
    {
        Debug.Log("Rotate!");

        Debug.Log("Rotate!");
        moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DORotate(new Vector3( _rotationAngle,0,0), _rotationTime, RotateMode.LocalAxisAdd)).SetEase(Ease.Linear);
        moveSequence.Append(transform.DORotate(new Vector3(- (_rotationAngle)*2 ,0,0), _rotationTime, RotateMode.LocalAxisAdd)).SetEase(Ease.Linear);
        moveSequence.Append(transform.DORotate(new Vector3( _rotationAngle,0,0), _rotationTime, RotateMode.LocalAxisAdd)).SetEase(Ease.Linear);
        moveSequence.SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        moveSequence.Play();
    }

}
