using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterVisualize : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _ui;
    [SerializeField] public GameObject _videoPanel;
    [SerializeField] GameObject _comands;

    public bool _firsthub = false;
    

    private bool _buttonCounterPressed = false;
    private bool _uiActive = false;

    private bool _paused;

    // Update is called once per frame
    void Update()
    {
        CheckPressed();
        OpenCounter();
        CloseCounter();
        _paused = PauseGame.GameIsPaused;
        CloseOnPause();
        CloseOnVideo();
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
                //Debug.Log("Open");
                
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
        if(_firsthub)
        {
            _comands.SetActive(true);
        }
    }

    public void CloseOnPause()
    {
        if(_paused)
        {
            Close();
        }
    }

    public void CloseOnVideo()
    {
        if(_videoPanel.activeSelf)
        {
            Close();
        }
    }

    public void CloseCounter()
    {
        if(_uiActive)
        {
            if(_buttonCounterPressed)
            {
                Close();
            }
        
        }
        
    }

    public void Close()
    {
        _ui.SetActive(false);
        _buttonCounterPressed=false;
        _animator.SetBool("IsOpen", false);
        //Debug.Log("Close");
        _uiActive = false;
        if(_firsthub)
        {
            _comands.SetActive(false);
            _firsthub = false;
        }
    }


    private void CheckPressed()
    {
        if(!_paused)
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown("joystick button 6") ) //Ciao Edoardo, lo sappiamo che questo linea di codice e la sua simile sono un abominio, ma altrimenti non funzionava #propotipo
            {
                _buttonCounterPressed=true;
                Debug.Log("buttonCounter");
            }
        }
    }


}
