using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FSM : MonoBehaviour
{
    [SerializeField] private GameObject _target; //L'FPS controller
    [SerializeField] private float _minChaseDistance = 3f;

    private FiniteStateMachine<NPC_FSM> _stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        _stateMachine = new FiniteStateMachine<NPC_FSM>(this);
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

    

    private float DistanceFromTarget() => Vector3.Distance(_target.transform.position, transform.position);
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
    }

    public override void Tik()
    {

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

    }

    public override void Exit()
    {
    
    }
}