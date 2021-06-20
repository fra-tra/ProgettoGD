using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] LevelLoader _levelLoader; 
    [SerializeField] GameObject _buttonUI; 
    [SerializeField] GameObject _videoPanel;
    [SerializeField] GameObject _post;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        CallSkip(); 
        if(_videoPanel.activeSelf)
        {
            _buttonUI.SetActive(true);
            _post.SetActive(false);
            
        }
        
            
    }

    void CallSkip()
    {
        if(Input.GetButton("Skip"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 )
            {
                _levelLoader.Skip(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                _levelLoader.SkipPredicted();
            }
        }
    }
}
