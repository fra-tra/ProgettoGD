using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPartVisualization : MonoBehaviour
{
    [SerializeField] GameObject _arm;
    [SerializeField] GameObject _head;
    [SerializeField] GameObject _side;
    //[SerializeField] GameObject _body;

    [SerializeField] GameObject _hammer;
    [SerializeField] GameObject _scalpel;
    [SerializeField] GameObject _key;
    [SerializeField] GameObject _ivy;
    [SerializeField] GameObject _sling;
    [SerializeField] GameObject _globe;
    [SerializeField] GameObject _gear;

    [SerializeField] GameObject _lifeOne;
    [SerializeField] GameObject _lifeTwo;

    //[SerializeField] Material _brokenMaterial;
    //[SerializeField] Material _veryBrokenMaterial;

    private Counter _myCounter;
    private int _first;
    private int _second;
    private int _lifeCounter;

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _first = _myCounter.GetFirstObject();
        _second = _myCounter.GetSecondObject();
        _lifeCounter =_myCounter.GetLifeCounter();

        VisualizeFirstObject();
        VisualizeRemainingLives();
        VisualizzeSecondObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VisualizeFirstObject()
    {
        if (_first == 1) //Hammer
        {
            _arm.SetActive(false);
            _hammer.SetActive(true);
            _scalpel.SetActive(true);
        }
        else if (_first == 3) //ivy
        {
            _side.SetActive(false);
            _ivy.SetActive(true);
        }
        else if (_first == 5) //globe
        {
            _head.SetActive(false);
            _globe.SetActive(true);
        }
    }

    private void VisualizzeSecondObject()
    {
        if (_second == 2) //key
        {
            _arm.SetActive(false);
            _key.SetActive(true);
        }
        else if (_second == 4) //sling
        {
            _side.SetActive(false);
            _sling.SetActive(true);
        }
        else if (_second == 6) //gear
        {
            _head.SetActive(false);
            _gear.SetActive(true);
        }
    }

    private void VisualizeRemainingLives()
    {
        if (_lifeCounter == 1 )
        {
            _lifeOne.SetActive(false);
            _lifeTwo.SetActive(false);
            //_body.GetComponent<MeshRenderer> ().material = _veryBrokenMaterial;//Assegnazione materiale rottissimo
        }
        else if (_lifeCounter == 2)
        {
            _lifeOne.SetActive(false);
            //_body.GetComponent<MeshRenderer> ().material = _brokenMaterial;//Assegnazione materiale rotto
        }
        
    }
}
