using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSpecialObject : MonoBehaviour
{
    private Counter _myCounter;

    private int _firstChoosenObject;
    private int _secondChoosenObject;
    private bool _allChoice = false;

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        if (_allChoice)
        {
            ChoiceDone();
        }
    }

    //i bottoni della scelta degli oggetti dovrebbero chiamare queste funzioni che settano i valori in counter (Magari passandogli l'int)

    public void EasyObjectChosen(int n)
    {
        _firstChoosenObject = n;
    }

    public void MediumObjectChosen(int n)
    {
        _firstChoosenObject = n;
        _allChoice = true;
    }

    public void ChoiceDone()
    {
        _myCounter.ChoosenObjects(_firstChoosenObject, _secondChoosenObject);
    }
  
}
