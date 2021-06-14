using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainManager : MonoBehaviour
{
    private Counter _myCounter;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _positionLower;
    [SerializeField] GameObject _positionUpper;
    [SerializeField] GameObject _firstRock;

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));

        if (_myCounter.GetIntern1())
        {
            //Sposta la transform del player
           _player.transform.position = _positionLower.transform.position;
           _myCounter.SetIntern1(false);
        }
        else if(_myCounter.GetIntern2())
        {
            _player.transform.position = _positionUpper.transform.position;
            _myCounter.SetIntern1(false);
        }

        if (_myCounter.GetFirstObject() == 1)
        {
            _firstRock.SetActive(false);
        }
    }
}
