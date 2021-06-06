using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTry : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _Cube;
    // Start is called before the first frame update
    void Start()
    {
        _player.transform.SetParent(this.transform,true);
        _Cube.transform.SetParent(this.transform,true);
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 10f * Time.deltaTime, 0));
    }
}
