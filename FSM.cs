public class FSM : MonoBehaviour
{
    private Dictionary<State, FSMState> states;
    private FSMState currentState;
    private GameObject npc;
    private Transform player;

    private void Start()
    {
        npc = gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        states = new Dictionary<State, FSMState>
        {
            { State.Idle, new IdleState(npc, player, this) },
            { State.Patrol, new PatrolState(npc, player, this) },
            { State.Chase, new ChaseState(npc, player, this) },
            { State.Attack, new AttackState(npc, player, this) }
        };

        currentState = states[State.Idle];
        currentState.Enter();
    }

    private void Update()
    {
        currentState.Execute();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = states[newState];
        currentState.Enter();
    }
}
