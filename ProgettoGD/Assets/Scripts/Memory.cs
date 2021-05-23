using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    private bool _memoryTaken = false;
    [SerializeField] private float _minDistance;
    [SerializeField] private GameObject _target; //Deve essere il third person controller

    // Start is called before the first frame update

    void Update()
    {
        if (IsTargetWithinDistance(_minDistance))
        {
            Debug.Log("Target vicino");
            CollectMemory();
        }
    }

    public void ObtainedMemory() //viene chiamata quando prendi l’oggetto e sparisce
    {
    	_memoryTaken = true;
    }

    public void LoosedMemory() // viene chiamata quando muori prima della fine del livello
    {
        _memoryTaken = false;
    }

    public bool IsTaken()
    {
        return _memoryTaken;
    }

    public void CollectMemory()
    {
        //Inserisci condizioni del caso per ogni livello
        //In quello della poesia epica deve essere libera dalla statua
        //in quella dell’astronomia il droide deve essersi fermato
        //La gestisce comunque la stessa variabile
        ObtainedMemory();
        gameObject.SetActive(false); //Non lo distruggo, lo faccio sparire, perché mi serve ancora che ci sia questo codice attivo per ottenere dati
    }

    private bool IsTargetWithinDistance(float distance)
    {
        return (_target.transform.position - transform.position).sqrMagnitude <= distance * distance;
    }

}
