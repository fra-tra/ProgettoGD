using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentStroll : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(DestinationReached())
            SetDestination();
    }

    private void SetDestination()
    {
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        Vector3 randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();
        
        while (!_navMeshAgent.CalculatePath(randomPosition, path))
        {
            randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();
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
}
