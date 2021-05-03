using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{

    private int _myMemoriesCounter = 0;
    [SerializeField] int _totalMemories;

    public static bool _takenMemoryZero = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCounter() //MODIFICARE
    {
        _myMemoriesCounter++; //il counter fa +1
        Debug.Log(_myMemoriesCounter);
    }
}
