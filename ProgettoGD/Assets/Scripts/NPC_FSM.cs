using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FSM : MonoBehaviour
{
    [SerializeField] private GameObject _target; //L'FPS controller
    [SerializeField] private float _minChaseDistance = 3f;
    [SerializeField] private Collider _groundCollider;
    [SerializeField] private Transform _playerTransf;
    [SerializeField] private float _ySpawn;

    private FiniteStateMachine<NPC_FSM> _stateMachine;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _stateMachine = new FiniteStateMachine<NPC_FSM>(this);
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        //STATES
        State patrolState = new PatrolState_NPC("Patrol", this); //Attende che l'utente sia nel suo raggio d'azione
        State chaseState = new ChaseState_NPC("Chase", this); //rincorre e/o spinge l'utente


        //TRANSITIONS
        _stateMachine.AddTransition(patrolState, chaseState, () => DistanceFromTarget() <= _minChaseDistance); //se la distanza è minore della minChaseDistance cambia stato e passa a chase
        _stateMachine.AddTransition(chaseState,patrolState, () => DistanceFromTarget() >= _minChaseDistance);

        //START STATE
        _stateMachine.SetState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tik();
    }

     public Vector3 GetRandomPositionOnGround()
    {
        Vector3 min = _groundCollider.bounds.min;
        Vector3 max = _groundCollider.bounds.max;
        return new Vector3(Random.Range(min.x, max.x), _ySpawn, Random.Range(min.z, max.z)); //_altezzaTerreno è la misura per farlo stare poggiato coi piedi sul ground
    }

    private float DistanceFromTarget() => Vector3.Distance(_target.transform.position, transform.position);

    public void SetDest()
    {
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        Vector3 randomPosition = GetRandomPositionOnGround();
        
        while (!_navMeshAgent.CalculatePath(randomPosition, path))
        {
            randomPosition = GetRandomPositionOnGround();
        }  
        _navMeshAgent.SetDestination(randomPosition);
        
    }

    public void FollowTarget()
    {
         _navMeshAgent.SetDestination(_playerTransf.position);
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

    public void DestinationTik()
    {
        if(DestinationReached())
            SetDest();
    }
}

public class PatrolState_NPC : State
{
    private NPC_FSM _guard;
    
    public PatrolState_NPC(string name, NPC_FSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        //non deve fare nulla (il controllo lo fa il cambio di stato)
        _guard.SetDest();
    }

    public override void Tik()
    {
        _guard.DestinationTik();
    }

    public override void Exit()
    {
        
    }

}

public class ChaseState_NPC : State
{
    private NPC_FSM _guard;

    public ChaseState_NPC(string name, NPC_FSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {

    }

    public override void Tik()
    {        
        _guard.FollowTarget();
    }

    public override void Exit()
    {
    
    }
}