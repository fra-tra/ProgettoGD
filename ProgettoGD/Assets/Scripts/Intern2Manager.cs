using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intern2Manager : MonoBehaviour
{
    private Counter _myCounter;
    [SerializeField] private LevelLoader _levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _myCounter.SetIntern2(true); //Deve essere settato a false appena ricarichi la montagna, ma dopo che lo controlli
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        _levelLoader.LoadLevelFromThis(-2);
        
    }
}
