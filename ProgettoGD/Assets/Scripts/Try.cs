using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.forward, out hit, 10))
        {

            var _objectTag = hit.collider.gameObject.tag;

            
            if (_objectTag == "MovingIsland")
            {
                
            }
        }
    }

}
