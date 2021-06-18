
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Memory : MonoBehaviour
{
    private bool _memoryTaken = false;
    [SerializeField] private float _minDistance;
    [SerializeField] private GameObject _target; //Deve essere il third person controller
    [SerializeField] private GameObject _UiMemoryThis; 

    [SerializeField] GameObject _part1;
    [SerializeField] GameObject _part2;
    [SerializeField] GameObject _part3;
    [SerializeField] GameObject _part4;

    [SerializeField] AudioSource audioSource; //AudioSource del ricordo
    [SerializeField] AudioClip feedbackRaccolta;
    public AudioSource _sourceCatch;
    
 
    [SerializeField] private CounterVisualize _uiCounter;



    
    // Start is called before the first frame update

    void Update()
    {
        if (IsTargetWithinDistance(_minDistance) && !_memoryTaken)
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
        ObtainedMemory();
        Debug.Log(_memoryTaken);

        _part1.SetActive(false);
        _part2.SetActive(false);
        _part3.SetActive(false);
        _part4.SetActive(false);
        audioSource.mute = true ;
        _sourceCatch.PlayOneShot(feedbackRaccolta);
        //Non lo distruggo, lo faccio sparire, perché mi serve ancora che ci sia questo codice attivo per ottenere dati

        _UiMemoryThis.SetActive(true);
        _uiCounter.MemoryTakenUI();

        Debug.Log("Presa memoria" + _memoryTaken);
    }

    private bool IsTargetWithinDistance(float distance)
    {
        return (_target.transform.position - transform.position).sqrMagnitude <= distance * distance;
    }

}
