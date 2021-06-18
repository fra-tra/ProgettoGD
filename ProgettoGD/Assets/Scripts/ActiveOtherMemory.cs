using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOtherMemory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _memoryUIOther;
    [SerializeField] private CounterVisualize _uiCounter;

    private Counter _myCounter;
    private int _OtherMemoryCounter;
    void Start()
    {
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        
        _OtherMemoryCounter = _myCounter.GetMemoryCounter(); 
        if(_OtherMemoryCounter == 1)
        {
            NotFirstLevel();
        }
    }

     public void NotFirstLevel()
    {
            _memoryUIOther.SetActive(true);

    }
}
