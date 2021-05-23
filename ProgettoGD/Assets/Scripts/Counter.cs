using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    //Tiene il conto dei ricordi
    //Tiene le informazioni sulle scelte fatte all'inizio
    //Tiene le info sul numero di vite

    private int _myMemoriesCounter = 0; //Contatore che conta i ricordi ottenuti
    private int _myLifeCounter; //Contatore che tiene conto delle vite

    [SerializeField] int _totalMemories; //numero totale ricordi
    [SerializeField] int _maxLives; //numero massimo vite

    public bool _takenMemoryZero = false;
    public bool _takenMemoryFour = false;

    public bool _lowerRoomEntered = false;
    public bool _upperRoomEntered = false;
    //Vengono settati a true quando entri. Ci sarà un gestore del livello che appena lo apre controlla questa cosa.
    //Se uno dei due è true sposta a “Davanti le porte di uscita” il TPC

    //Variabili riferite agli oggetti speciali che tengono conto di quali sono stati scelti
    private int _firstChoosenObject = 0;
    private int _secondChoosenObject = 0;
    //hammer 1
    //key 2
    //ivy 3
    //sling 4
    //globe 5
    //gear 6

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _myLifeCounter =  _maxLives;
    }
    
    void Update()
    {
        //
    }

    public int GetFirstObject()
    {
        return _firstChoosenObject;
    }

    public int GetSecondObject()
    {
        return _secondChoosenObject;
    }

    public void FirstChoosenObject(int first)
    {
        _firstChoosenObject = first;
    }

    public void SecondChoosenObject(int second)
    {
        _secondChoosenObject = second;
    }

    public void UpdateCounter() //Gestisce il counter dei ricordi. Deve essere chiamato appena termini il livello definitivamente
    {
        _myMemoriesCounter++; //il counter fa +1
        Debug.Log(_myMemoriesCounter);
    }

    public bool UpdateCounterOnDeath() //Funzione che il DeathManager deve chiamare per decrementare il contatore di vite
    {
        _myLifeCounter = _myLifeCounter - 1;
        Debug.Log(_myLifeCounter);

        if (_myLifeCounter == 0)
        {
            return true; //Ritorna "True" a _livesFinished. Ci sarà una funzione che attiva la cutscene e chiama il level loader verso l'hub0
        }
        else
        {
            return false; //Ritorna "False" a come _livesFinished. Ci sarà una funzione che attiva la cutscene e chiama il level loader verso l'inizio del livello stesso
        }
    }
}
