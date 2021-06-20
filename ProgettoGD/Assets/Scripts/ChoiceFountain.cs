using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChoiceFountain : MonoBehaviour
{
    [SerializeField] GameObject _fountain; 
    [SerializeField] Material _matFountainGlow;
    // Start is called before the first frame update
    [SerializeField] public VideoPlayer _video;
    [SerializeField] public GameObject _videoPanel;
    [SerializeField] public LevelLoader _levelLoader;
    [SerializeField] public GameObject _post;
    [SerializeField] GameObject _ui;

    private Material _matF;
    private Coroutine _coroutine;
    private bool _notChoosen = true;
    private bool _memoryPlayed = false;
    public float transitionTime = 1f;

    private Counter _myCounter;
    void Start()
    {
        _matF= _fountain.GetComponent<MeshRenderer> ().material;
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _fountain.GetComponent<MeshRenderer> ().material = _matFountainGlow;
        _post.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _fountain.GetComponent<MeshRenderer> ().material = _matF;
        _post.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag =="Player")
        {
            CheckChoice();
        }
    }

    private void CheckChoice()
    {
        if(Input.GetButton("SpecialObject") && _notChoosen)
        {
            _notChoosen = false;
            _coroutine = StartCoroutine(CoroutinePlayVideo());
        }
    }

    public IEnumerator CoroutinePlayVideo()
    {   Debug.Log("ChoiceVideo");
        _videoPanel.SetActive(true);
        _video.playOnAwake = false;

        _ui.SetActive(false);

        _video.Play();
        transitionTime = (float) _video.length;
        yield return new WaitForSeconds(transitionTime + 0.1f);
        
        //_videoPanel.SetActive(false);
        _myCounter.Reset();
        _levelLoader.ToMenu();
        StopCoroutine(_coroutine);
    }
}
