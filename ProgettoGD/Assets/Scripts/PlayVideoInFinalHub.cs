
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
    public Rigidbody _playerRB;
    

    private int _level;
    private bool _mTaken = false;
    private bool _memoryPlayed = false;
    public float transitionTime = 1f;
    private Coroutine _coroutine;

    void Update()
    {   
        //_level = _levelLoader.CurrentLevel(); 
        _mTaken = _memory.IsTaken();

        if( /*_level == 9 && */ _mTaken && !_memoryPlayed)
        {
            Debug.Log("If fatto");
            _coroutine = StartCoroutine(PlayVideoMemory());
        }
    }

 
    public IEnumerator PlayVideoMemory()
    {
        _playerRB.isKinematic = true;
        Debug.Log("memoriaPresaVideo");
        _videoPanel.SetActive(true);
        _video.playOnAwake = false;

        _video.Play();
        transitionTime = (float) _video.length;
        _memoryPlayed = true;
        yield return new WaitForSeconds(transitionTime + 0.1f);
        _playerRB.isKinematic = false;

        _videoPanel.SetActive(false);
        StopCoroutine(_coroutine);
    }
}
