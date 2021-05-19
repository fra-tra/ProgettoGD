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
    private bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (!entered)
        {
            entered=true;
            SpawnRocks();
        }
        //_coroutine = StartCoroutine(MyCoroutine());
    }


    /*public IEnumerator MyCoroutine()
    {
        Debug.Log("In corout");
        SpawnRocks();
        yield return new WaitForSeconds(Random.Range(10000f , 20000f));
        Debug.Log("After Yield");
        StopCoroutine(_coroutine);
    }
*/
    public void SpawnRocks()
    {
        for (int i = 0; i < _rocksToSpawn; i++)
        {
            Debug.Log("Spawn");
            Instantiate(_rockPrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    public Vector3 GetRandomPosition()
    {
            Vector3 min = _space.bounds.min;
            Vector3 max = _space.bounds.max;
            return new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
    }

}
