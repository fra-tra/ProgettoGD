using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    //Tiene il conto dei ricordi
    //Tiene le informazioni sulle scelte fatte all'inizio
    //Tiene le info sul numero di vite

    private int _myMemoriesCounter = 0;
    [SerializeField] int _totalMemories; //numero totale ricordi
    [SerializeField] int _maxLives; //numero massimo vite

    public static bool _takenMemoryZero = false;
    public static bool _takenMemoryFour = false;

    //Variabili riferite agli oggetti speciali che tengono conto di quali sono stati scelti
    private int _firstChoosenObject;
    private int _secondChoosenObject;
    //hammer 1
    //key 2
    //ivy 3
    //sling 4
    //globe 5
    //gear 6

    public int GetFirstObject()
    {
        return _firstChoosenObject;
    }

    public int GetSecondObject()
    {
        return _secondChoosenObject;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoosenObjects(int first, int second)
    {
        _firstChoosenObject = first;
        _secondChoosenObject = second;
    }

    public void UpdateCounter() //MODIFICARE
    {
        _myMemoriesCounter++; //il counter fa +1
        Debug.Log(_myMemoriesCounter);
    }
}
