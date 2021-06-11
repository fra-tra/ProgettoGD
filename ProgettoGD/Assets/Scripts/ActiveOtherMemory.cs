using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOtherMemory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _AnelloUIOther; 
    [SerializeField] private GameObject _NucleoUIOther; //Deve essere il third person controller
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

    // Update is called once per frame


     public void NotFirstLevel()
    {
            _AnelloUIOther.SetActive(true);
            _NucleoUIOther.SetActive(true);

    }
}
