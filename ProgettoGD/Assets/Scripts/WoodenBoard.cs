using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WoodenBoard : MonoBehaviour
{
    private bool _playerStanding = false;
    private Coroutine _coroutine;
    public Rigidbody rb;
    [SerializeField] AudioSource soundWood;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !_playerStanding)
        {
            Debug.Log("PlayerON");
            _playerStanding = true;
            ShakeBoard();
            _coroutine = StartCoroutine(CoroutineCountdown());//Chiama coroutine
        }
    }

    //Coroutine
    public IEnumerator CoroutineCountdown()
    {
        yield return new WaitForSeconds(Random.Range(1.5f , 3f));
        Debug.Log("Waited");
        if (_playerStanding)
        {
            Debug.Log("Broken");
            rb.isKinematic = false; //Si rompe e cade nella lava
        }
        StopCoroutine(_coroutine);
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.tag == "Player")
       {
           _playerStanding = false;
       }
    }


    private void ShakeBoard() //MOVIMENTO ASSI
    {
        Debug.Log("Shake!");
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOShakeScale(2f, new Vector3(0.3f, 0.3f, 0.3f)));
        moveSequence.Play();
        soundWood.Play();
    }
}
