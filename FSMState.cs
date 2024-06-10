public abstract class FSMState
{
public enum State
{
    Idle,
    Patrol,
    Chase,
    Attack
}

    protected GameObject npc;
    protected Transform player;
    protected FSM fsm;

    public FSMState(GameObject npc, Transform player, FSM fsm)
    {
        this.npc = npc;
        this.player = player;
        this.fsm = fsm;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
