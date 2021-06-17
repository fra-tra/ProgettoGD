using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMemory : MonoBehaviour
{
    [SerializeField] public GameObject _myPrefab; //DustCloud
    [SerializeField] public GameObject _myPrefabBrokenPieces;
    [SerializeField] public GameObject _statue;
    [SerializeField] public AudioSource audioSource;

    private Counter _myCounter;
    private Coroutine _coroutine;
    private Rigidbody rb;
    private bool _destroyable = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _myCounter = (Counter)FindObjectOfType(typeof(Counter));

        if (_myCounter.GetFirstObject() == 1) //Se si ha il martello
        {
           rb.isKinematic = true; //Le statue non sono più rompibili

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hitHammer()
    {
        //Statua colpita dal martello
        _coroutine = StartCoroutine(delayDestroyHammer());
        audioSource.Play();
    }

    public void hitFloor()
    {
        //Statua colpisce terreno
         DestroyStatue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RockFloor" && _destroyable) //Controlla che abbia colpito il terreno
        {
            _destroyable = false;
            hitFloor();
        }
    }

    public void DestroyStatue()
    {
        Debug.Log("Destroy statue");
        //Istanzia un nuovo effetto particellare dello standard asset che si chiama Dust Cloud
        Instantiate(_myPrefab, this.transform.position , Quaternion.identity);
        Instantiate(_myPrefabBrokenPieces, this.transform.position , Quaternion.identity);
        Destroy(_statue);
        Destroy(rb);
    }

     public IEnumerator delayDestroyHammer()
    {
         yield return new WaitForSeconds(1f);

        Debug.Log("Dopo Yield coroutine use object");
        DestroyStatue();
        StopCoroutine(_coroutine);

    }
}
