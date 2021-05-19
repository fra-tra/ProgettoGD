using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    //Deve essere assegnato al TPC

    private Counter _myCounter;
    [SerializeField] private LevelLoader _levelLoader;
    
    private bool _livesFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeadlySituation();
    }

    public void CheckDeadlySituation ()
    {
        //Chiama isDead nel momento in cui il raycasting incontra un posto in cui si muore (Dove puoi risolverla col raycasting della camminata)
    }


    private void OnCollisionEnter(Collision collision)	//Se attaccato al controller si accerta che non ci siano collisioni con rocce, in caso decrementa la vita
    {
        //Dovrebbe essere chiamata automaticamente ad ogni collisione
        if (collision.gameObject.tag == "FallingRock")
        {
            Debug.Log("Colpito da una roccia aaaah ahia");
            isDead();
        }

    }


    public void isDead() //Può essere chiamata anche a altre situazioni
    {
        _livesFinished = _myCounter.UpdateCounterOnDeath(); //Decrementa il contatore delle vite e ottiene un bool

        if (_livesFinished)
        {
            _myCounter._takenMemoryZero = false;
           _levelLoader.LastDeath(); //è morto definitivamente, setta la variabile morto 
            //CUT SCENE COME?
        }
        else
        {
            _levelLoader.Death(); //ha perso una vita, setta la variabile morto
            //CUT SCENE COME?
        }
        _levelLoader.LoadNextLevel();
    }
    
}
