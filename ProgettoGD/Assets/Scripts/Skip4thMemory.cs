using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Skip4thMemory : MonoBehaviour
{ 
    [SerializeField] GameObject _videoPanel;
    [SerializeField] public VideoPlayer _video;
    public Rigidbody _playerRB;
    private Coroutine _coroutine;
    private float transitionTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_videoPanel.activeSelf)
        {
            _coroutine = StartCoroutine(playVideo());
            _playerRB.isKinematic = true;
        }
    }

    IEnumerator playVideo()
    {
        transitionTime = (float)_video.length;
        yield return new WaitForSeconds(transitionTime + 0.1f);
        _playerRB.isKinematic = false;
        StopCoroutine(_coroutine);
    }

}
