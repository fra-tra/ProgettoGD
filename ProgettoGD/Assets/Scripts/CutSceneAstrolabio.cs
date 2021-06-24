using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAstrolabio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Cam1;
    //[SerializeField] GameObject Cam2;
    [SerializeField] GameObject CamPlayer;
    [SerializeField] GameObject CutSceneEmpty;

    private bool _end = false;

    private Coroutine _coroutine;
    void Start()
    {
        _coroutine = StartCoroutine(Sequence());
        //
    }

    void Update()
    {
        if(_end)
        {
            CamPlayer.SetActive(true);
            Cam1.SetActive(false);
            CutSceneEmpty.SetActive(false);
            _end = false;
        }
        

    }

    IEnumerator Sequence()
    {
        Cam1.SetActive(true);
        CamPlayer.SetActive(false);
        yield return new WaitForSeconds(5.5f);
        /*Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(5f);*/
        CamPlayer.SetActive(true);
        Cam1.SetActive(false);
        
        _end = true;
        StopCoroutine(_coroutine);

    }
}
