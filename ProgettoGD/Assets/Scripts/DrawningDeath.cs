using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawningDeath : MonoBehaviour
{
    [SerializeField] DeathManager _death;

    private bool _dead=false;
    
    //Sia per Oceano che per Lava
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_dead)
        {
            Debug.Log("Drawning");
            _dead = true;
            _death.isDead();
        }
    }
}
