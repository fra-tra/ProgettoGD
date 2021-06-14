using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentStroll : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    [SerializeField] private Collider _groundCollider;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _minChaseDistance = 1f;
    [SerializeField] float _waitingTime = 6f;

    private bool _Patrolling = true;
    private Counter _myCounter;
    private bool _stopped = false;
    private Coroutine _coroutine;
    private int _firstObject;

    void Start()
    {
        Debug.Log("Start");
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(GetRandomPositionOnGround());

        _myCounter = (Counter)FindObjectOfType(typeof(Counter));
        _firstObject = _myCounter.GetFirstObject();

    }

    void Update()
    {
        if (!_stopped)
        {
            if ( DistanceFromTarget() <= _minChaseDistance)
            {
                _Patrolling = false;
                ChaseTarget();
                CheckGlobe();
            }
            else
            {
                if( DestinationReached() && _Patrolling)
                {
                    Debug.Log("Setting new");
                    SetNewDestination();
                }
            }
        }
            
    }

    private void CheckGlobe()
    {
        if (  _firstObject ==  5 && Input.GetButton("SpecialObject"))
        {
            _stopped = true;
            _coroutine = StartCoroutine(WaitRestartChasing());
        }
    }

    public IEnumerator WaitRestartChasing()
    {
        yield return new WaitForSeconds(_waitingTime);
        Debug.Log("Chasing paused");
        _stopped = false;
        _Patrolling = true;
        StopCoroutine(_coroutine);
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

    private void ChaseTarget()
    {
        Debug.Log("ChaseTarget");
        _navMeshAgent.SetDestination(_target.transform.position);
        _Patrolling = true;
    }

    private bool DestinationReached()
    {
        
        if (!_navMeshAgent.pathPending)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude <= 0f)
                    {
                        Debug.Log("navigation Reached");
                        return true;
                    }
                    
        return false;
    }

    public Vector3 GetRandomPositionOnGround()
    {
        Debug.Log("random position");
        Vector3 min = _groundCollider.bounds.min;
        Vector3 max = _groundCollider.bounds.max;
        Debug.Log(max);
        return new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
    }

   private float DistanceFromTarget() => Vector3.Distance(_target.transform.position, transform.position);
}
