using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    //DEVONO ESSERE RIGIDBODY PER PPOTER ESSERE SPINTE

    [SerializeField] public GameObject _myPrefab; //DustCloud
    
    private Counter _myCounter;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));

        //if (_myCounter.GetFirstObject() == 1) //Se si ha il martello
        //{
            rb.isKinematic = true; //Le statue non sono più rompibili
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitHammer()
    {
        //Statua colpita dal martello
        //istanzia un particellare di polvere
        DestroyStatue();
    }

    public void hitFloor()
    {
        //Statua colpisce terreno
         DestroyStatue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RockFloor") //Controlla che abbia colpito il terreno
        {
            hitFloor();
        }
    }

    public void DestroyStatue()
    {
        Debug.Log("Destroy statue");
        //Istanzia un nuovo effetto particellare dello standard asset che si chiama Dust Cloud
        Instantiate(_myPrefab, this.transform.position , Quaternion.identity);

        Destroy(this);//cancella l'oggetto
    }
}
