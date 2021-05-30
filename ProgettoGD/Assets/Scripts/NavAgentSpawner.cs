using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _navAgentPrefab;
    [SerializeField] private int _navMeshAgentsToSpawn = 10;
    [SerializeField] private Collider _groundCollider;
    [SerializeField] private float _altezzaTerreno = 0f;

    private static NavAgentSpawner _instance;

    public static NavAgentSpawner Instance => _instance;

    void Start()
    {
        Debug.Log("Spawned");
        _instance = this;
        SpawnNavMeshAgents();
    }

    private void SpawnNavMeshAgents()
    {
        for (int i = 0; i < _navMeshAgentsToSpawn; i++)
        {
            Debug.Log("Hello I'm navmesh");
            GameObject agent = Instantiate(_navAgentPrefab, GetRandomPositionOnGround(), Quaternion.identity);
            NavAgentStroll targetReached = agent.GetComponent<NavAgentStroll>();
        }
    }

    
    public Vector3 GetRandomPositionOnGround()
    {
        Vector3 min = _groundCollider.bounds.min;
        Vector3 max = _groundCollider.bounds.max;
        return new Vector3(Random.Range(min.x, max.x), _altezzaTerreno, Random.Range(min.z, max.z)); //_altezzaTerreno è la misura per farlo stare poggiato coi piedi sul ground
    }
}
