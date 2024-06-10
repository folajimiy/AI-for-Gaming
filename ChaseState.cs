public class ChaseState : FSMState
{
    public ChaseState(GameObject npc, Transform player, FSM fsm) : base(npc, player, fsm) { }

    public override void Enter()
    {
        Debug.Log("Entering Chase State");
    }

    public override void Execute()
    {
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, player.position, Time.deltaTime * 3);

        if (Vector3.Distance(npc.transform.position, player.position) < 2)
        {
            fsm.ChangeState(State.Attack);
        }

        if (Vector3.Distance(npc.transform.position, player.position) > 10)
        {
            fsm.ChangeState(State.Patrol);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Chase State");
    }
}
