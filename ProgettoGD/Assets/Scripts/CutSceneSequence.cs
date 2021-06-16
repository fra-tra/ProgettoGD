using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSequence : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Cam1;
    [SerializeField] GameObject Cam2;
    [SerializeField] GameObject Cam3;
    [SerializeField] GameObject Cam4;
    [SerializeField] GameObject Cam5;
    [SerializeField] GameObject CamPlayer;
    [SerializeField] AudioSource _source;

    [SerializeField] GameObject CutSceneEmpty;

    private Coroutine _coroutine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter()
    {
        _source.Play();

        _coroutine = StartCoroutine(Sequence());

    }

    IEnumerator Sequence()
    {
        Cam1.SetActive(true);
        CamPlayer.SetActive(false);
        yield return new WaitForSeconds(9.5f);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(1f);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(1.8f);

        Cam4.SetActive(true);
        Cam3.SetActive(false);
        yield return new WaitForSeconds(1.7f);
        Cam5.SetActive(true);
        Cam4.SetActive(false);
        yield return new WaitForSeconds(2.4f);
        CamPlayer.SetActive(true);
        Cam5.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        CutSceneEmpty.SetActive(false);
        StopCoroutine(_coroutine);
        
    }
}
