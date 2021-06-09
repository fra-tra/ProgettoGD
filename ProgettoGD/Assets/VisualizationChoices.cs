using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizationChoices : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _hammer;
    [SerializeField] GameObject _scalpel;
    [SerializeField] GameObject _key;
    [SerializeField] GameObject _ivy;
    [SerializeField] GameObject _sling;
    [SerializeField] GameObject _globe;
    [SerializeField] GameObject _gear;

    private Counter _myCounter;
    private int _first;

    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _first = _myCounter.GetFirstObject();
        VisualizeFirstObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VisualizeFirstObject()
    {
        if (_first == 1) //Hammer
        {
            _hammer.SetActive(true);
            _scalpel.SetActive(true);
        }
        else if (_first == 3) //ivy
        {
            _ivy.SetActive(true);
        }
        else if (_first == 5) //globe
        {
            _globe.SetActive(true);
        }
    }
}
