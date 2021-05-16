using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{

    [SerializeField] public GameObject _myPrefab; //DustCloud
    // Start is called before the first frame update
    void Start()
    {
        
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
        //Controlla che abbia colpito il terreno
    }

    public void DestroyStatue()
    {
        //Istanzia un nuovo effetto particellare dello standard asset che si chiama Dust Cloud
        Instantiate(_myPrefab, this.transform.position , Quaternion.identity);

        Destroy(this);//cancella l'oggetto
    }
}
