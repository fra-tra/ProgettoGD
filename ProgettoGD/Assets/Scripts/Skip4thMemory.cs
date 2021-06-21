using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Skip4thMemory : MonoBehaviour
{
    [SerializeField] GameObject _buttonUI; 
    [SerializeField] GameObject _videoPanel;
    [SerializeField] public VideoPlayer _video;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_videoPanel.activeSelf)
        {
            CallSkipMem();
            _buttonUI.SetActive(true);
        }
    }

    public void CallSkipMem()
    {   
        if(Input.GetButton("Skip"))
        {
            _video.Stop();
            _videoPanel.SetActive(false);
            _buttonUI.SetActive(false);
        }

    }
}
