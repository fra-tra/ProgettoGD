
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideoInFinalHub : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] public Memory _memory;
    [SerializeField] public VideoPlayer _video;
    [SerializeField] public GameObject _videoPanel;
    [SerializeField] public LevelLoader _levelLoader;
    [SerializeField] public Memory _memory;

    private int _level;
    private bool _mTaken = false;
    private bool _memoryPlayed = false;
    public float transitionTime = 1f;

    void Update()
    {   
        _level = _levelLoader.CurrentLevel(); 
        _mTaken = _memory.IsTaken();

        if(_level == 9 && _mTaken && !_memoryPlayed)
        {
            Debug.Log("If fatto");
            PlayVideoMemory();
        }
    }

 
    IEnumerator PlayVideoMemory()
    {
        
            Debug.Log("memoriaPresaVideo");
            _videoPanel.SetActive(true);
            _video.playOnAwake = false;

            _video.Play();
            transitionTime = (float) _video.length;
            yield return new WaitForSeconds(transitionTime + 0.1f);
            _memoryPlayed = true;

            _videoPanel.SetActive(false);
    }
}
