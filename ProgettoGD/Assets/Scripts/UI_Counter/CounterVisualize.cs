using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterVisualize : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _ui;
    

    private bool _buttonCounterPressed = false;
    private bool _uiActive = false;

    private bool _paused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPressed();
        OpenCounter();
        CloseCounter();
        _paused = PauseGame.GameIsPaused;
    }

    public void OpenCounter()
    {
        if(!_uiActive)
        {  
            if(_buttonCounterPressed)
            {
                _ui.SetActive(true);
                _uiActive = true;
                _animator.SetBool("IsOpen", true);
                _buttonCounterPressed = false;
                Debug.Log("Open");
            }
        }
    }

    public void MemoryTakenUI()
    {
        _ui.SetActive(true);
        _uiActive = true;
        _animator.SetBool("IsOpen", true);
        _buttonCounterPressed = false;
        Debug.Log("Open");
    }

    public void CloseCounter()
    {
        if(_uiActive)
        {
            if(_buttonCounterPressed)
            {
                _ui.SetActive(false);
                _buttonCounterPressed=false;
                _animator.SetBool("IsOpen", false);
                Debug.Log("Close");
                _uiActive = false;
            }
        
        }
        
    }

    private void CheckPressed()
    {
        if(!_paused)
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown("joystick button 6") ) //Ciao Edoardo, lo sappiamo che questo linea di codice e la sua simile sono un abominio, ma altrimenti non funzionava #propotipo
            {
                _buttonCounterPressed=true;
            }
        }
    }


}
