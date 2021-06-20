using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    //Deve essere assegnato al TPC

    private Counter _myCounter;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] AudioSource feedbackDeath;
    private bool _hittable = true;
    
    private bool _livesFinished = false;

    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeadlySituation();
    }

    public void CheckDeadlySituation ()
    {
        //Chiama isDead nel momento in cui si è in una DeadlySituation
        //Lava, Oceano e Pietre già gestite
    }


    private void OnCollisionEnter(Collision collision)	//Se attaccato al controller si accerta che non ci siano collisioni con rocce, in caso decrementa la vita
    {
        //Dovrebbe essere chiamata automaticamente ad ogni collisione
        Debug.Log("Colpito da oggetto");
        if (collision.gameObject.tag == "FallingRock" && _hittable)
        {
            _hittable = false;
            Debug.Log("Colpito da una roccia aaaah ahia");
            feedbackDeath.Play();
            _animator.SetTrigger("isDead");
            isDead();
        }

    }


    public void isDead() //Può essere chiamata anche a altre situazioni
    {
        _livesFinished = _myCounter.UpdateCounterOnDeath(); //Decrementa il contatore delle vite e ottiene un bool

        if (_livesFinished)
        {
            _myCounter.Reset();
           _levelLoader.LastDeath(); //è morto definitivamente, setta la variabile morto 
        }
        else
        {
            _levelLoader.Death(); //ha perso una vita, setta la variabile morto
        }
        _levelLoader.LoadNextLevel();
    }
    
}
