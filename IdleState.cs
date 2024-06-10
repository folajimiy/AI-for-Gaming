public class IdleState : FSMState
{
    private float idleTime;

    public IdleState(GameObject npc, Transform player, FSM fsm) : base(npc, player, fsm) { }

    public override void Enter()
    {
        idleTime = Time.time + Random.Range(2, 5);
        Debug.Log("Entering Idle State");
    }

    public override void Execute()
    {
        if (Time.time > idleTime)
        {
            fsm.ChangeState(State.Patrol);
        }
        if (Vector3.Distance(npc.transform.position, player.position) < 10)
        {
            fsm.ChangeState(State.Chase);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
