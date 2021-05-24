using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawningDeath : MonoBehaviour
{
    [SerializeField] DeathManager _death;
    
    //Sia per Oceano che per Lava
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Drawning");
            _death.isDead();
        }
    }
}
