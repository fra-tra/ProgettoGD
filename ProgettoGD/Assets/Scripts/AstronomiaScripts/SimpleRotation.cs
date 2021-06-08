using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] float _waitingTime = 5f;
    [SerializeField] float _rotationAngle = 360f;
    [SerializeField] float _rotationTime = 30f;

     private Sequence moveSequence;

    // Start is called before the first frame update
    void Start()
    {
        SimpleRot();
    }

    private void SimpleRot()
    {
        Debug.Log("Rotate!");
        moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DORotate(new Vector3(0, _rotationAngle,0), _rotationTime, RotateMode.LocalAxisAdd)).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        moveSequence.Play();
    }
}
