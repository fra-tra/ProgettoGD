using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    [SerializeField] float _rotationTime = 5f;
    [SerializeField] float  _rotationAngle = 360;
    // Start is called before the first frame update
    void Start()
    {
        SimpleRotation();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SimpleRotation() //MOVIMENTO ASSI
    {
        Debug.Log("Rotate!");
        transform.DORotate(new Vector3(0, _rotationAngle ,0), _rotationTime , RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
