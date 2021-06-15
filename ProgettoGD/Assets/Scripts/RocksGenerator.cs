using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksGenerator : MonoBehaviour
{
    //Appena entri nel trigger inizia ad Istanziare rocce che cadono
    //Appena esci dal trigger smette

    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private int _rocksToSpawn = 2;
    [SerializeField] private Collider _space; //Il collider che si decide di passargli

    private Coroutine _coroutine;
    private bool _falling = false;
    private bool _rightTime = true;

    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_falling && _rightTime)
        {
            _coroutine = StartCoroutine(MyCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _falling = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered");
        if (other.tag == "Player")
        {
            _falling = true;
        }
    }

    public IEnumerator MyCoroutine()
    {
        Debug.Log("In corout");
        SpawnRocks();
        _rightTime = false;
        yield return new WaitForSeconds(Random.Range(1f , 5f));
        Debug.Log("After Yield");
        _rightTime = true;
        StopCoroutine(_coroutine);
    }

    public void SpawnRocks()
    {
        int max = (int)Random.Range(1, _rocksToSpawn);
        for (int i = 0; i < max; i++)
        {
            Debug.Log("Spawn");
            Object obj = Instantiate(_rockPrefab, GetRandomPosition(), Quaternion.identity);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(obj, 2);
        }
    }

    public Vector3 GetRandomPosition()
    {
            Vector3 min = _space.bounds.min;
            Vector3 max = _space.bounds.max;
            return new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
    }

}
