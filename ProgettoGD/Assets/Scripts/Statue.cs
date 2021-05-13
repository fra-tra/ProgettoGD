using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
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
    }

    public void hitFloor()
    {
        //Statua colpisce terreno
        //Controlla che abbia colpito il terreno
    }

    public void DestroyStatue()
    {
        //istanzia un particellare di polvere
        Destroy(this);//cancella l'oggetto
    }
}
