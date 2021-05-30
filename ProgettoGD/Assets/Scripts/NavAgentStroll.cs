using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentStroll : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    [SerializeField] private Collider _groundCollider;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination( GetRandomPositionOnGround() );
    }

    void Update()
    {
        if(DestinationReached())
            SetNewDestination();
    }

    private void SetNewDestination()
    {
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        Vector3 randomPosition = GetRandomPositionOnGround();
        
        while (!_navMeshAgent.CalculatePath(randomPosition, path))
        {
            randomPosition = GetRandomPositionOnGround();
        }  
        _navMeshAgent.SetDestination(randomPosition);
        
    }

    private bool DestinationReached()
    {
        if (!_navMeshAgent.pathPending)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude <= 0f)
                    {
                        return true;
                    }
                    
        return false;
    }

    public Vector3 GetRandomPositionOnGround()
    {
        Vector3 min = _groundCollider.bounds.min;
        Vector3 max = _groundCollider.bounds.max;
        return new Vector3(Random.Range(min.x, max.x), 0.1f, Random.Range(min.z, max.z)); //_altezzaTerreno è la misura per farlo stare poggiato coi piedi sul ground
    }
}
