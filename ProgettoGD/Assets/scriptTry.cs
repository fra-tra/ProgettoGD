using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTry : MonoBehaviour
{
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
         _player.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
