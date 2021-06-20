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

    public int easy;
    public int medium;
    public int difficult;
    // Epic poetry 4
    // Comedy 7
    // Astronomy 8

    public bool _easyLevel = true;
    public bool _mediumLevel = false;
    public bool _difficultLevel = false;
    public bool _returnedMenu = false;

    public static bool _logoplayed=false;

    public bool GetLogoPlayed()
    {
        return _logoplayed;
    }

    public void SetLogoPlayed(bool b)
    {
        _logoplayed=b;
    }
    

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
        if(_returnedMenu)
        {
            Destroy(gameObject);
        }
    }

    public bool GetEasy()
    {
        return _easyLevel;
    }

    public void SetEasy(bool e)
    {
        _easyLevel = e;
    }

    public bool GetMedium()
    {
        return _mediumLevel;
    }

    public void SetMedium(bool m)
    {
        _mediumLevel = m;
    }

    public bool GetDifficult()
    {
        return _difficultLevel;
    }

    public void SetDifficult(bool d)
    {
        _difficultLevel = d;
    }

    public int GetFirstObject()
    {
        return _firstChoosenObject;
    }


    public int GetSecondObject()
    {
        return _secondChoosenObject;
    }

    public int GetLifeCounter()
    {
        return _myLifeCounter;
    }

    public int GetMemoryCounter()
    {
        return _myMemoriesCounter;
    }

    public void SetIntern1(bool _entered)
    {
        _lowerRoomEntered = _entered;
    }

    public void SetIntern2(bool _entered)
    {
        _upperRoomEntered = _entered;
    }

    public bool GetIntern1()
    {
        return _lowerRoomEntered;
    }

    public bool GetIntern2()
    {
        return _upperRoomEntered;
    }

    public void ResetLives(int n)
    {
        _myLifeCounter = n;
    }

    public void FirstChoosenObject(int first)
    {
        _firstChoosenObject = first;
        if(first == 1)//hammer
        {
            easy = 4; //epic
        }
        else if (first == 3) //ivy
        {
            easy = 7; //comm
        }
        else if (first == 5) //globe
        {
            easy = 8; //Astro
        }

        Debug.Log("easy level is" + easy);
    }

    public void SecondChoosenObject(int second)
    {
        _secondChoosenObject = second;
        if(second == 2) //key
        {
            medium = 4; //epic
            if (_firstChoosenObject == 3) //ivy
            {
                difficult = 8; //astro
            }
            else if (_firstChoosenObject == 5) //globe
            {
                difficult = 7; //comm
            }
        }
        else if (second == 4) //Sling
        {
            medium = 7; //comm
            if (_firstChoosenObject == 1) //hammer
            {
                difficult = 8; //astro
            }
            else if (_firstChoosenObject == 5) //globe
            {
                difficult = 4; //epic
            }
        }
        else if ( second == 6) //gear
        {
            medium = 8; //astro
            if (_firstChoosenObject == 3) //ivy
            {
                difficult = 4; //epic
            }
            else if (_firstChoosenObject == 1) //hammer
            {
                difficult = 7; //comm
            }
        }
    }

    public void UpdateCounter() //Gestisce il counter dei ricordi. Deve essere chiamato appena termini il livello definitivamente
    {
        _myMemoriesCounter++; //il counter fa +1
        Debug.Log(_myMemoriesCounter);
    }
    
    public void UpdateCounterToMenu() //Funzione che il DeathManager deve chiamare per decrementare il contatore di vite
    {
        _myMemoriesCounter = 0;
    }

    public bool UpdateCounterOnDeath() //Funzione che il DeathManager deve chiamare per decrementare il contatore di vite
    {
        _myLifeCounter = _myLifeCounter - 1;
        Debug.Log(_myLifeCounter);

        if (_myLifeCounter == 0)
        {
            _myMemoriesCounter = 0;
            return true; //Ritorna "True" a _livesFinished. Ci sarà una funzione che attiva la cutscene e chiama il level loader verso l'hub0
        }
        else
        {
            return false; //Ritorna "False" a _livesFinished. Ci sarà una funzione che attiva la cutscene e chiama il level loader verso l'inizio del livello stesso
        }
    }

    public void Reset()
    {
        _takenMemoryZero = false;
        _takenMemoryFour = false;
        _myMemoriesCounter = 0;
        ResetLives(_maxLives);
        SetIntern1(false);
        SetIntern2(false);
        SetEasy(true);
        SetMedium(false);
        SetDifficult(false);
    }
}
