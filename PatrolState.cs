public class PatrolState : FSMState
{
    private Vector3 nextPoint;

    public PatrolState(GameObject npc, Transform player, FSM fsm) : base(npc, player, fsm) { }

    public override void Enter()
    {
        nextPoint = GetRandomPoint();
        Debug.Log("Entering Patrol State");
    }

    public override void Execute()
    {
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, nextPoint, Time.deltaTime * 2);

        if (Vector3.Distance(npc.transform.position, player.position) < 10)
        {
            fsm.ChangeState(State.Chase);
        }

        if (Vector3.Distance(npc.transform.position, nextPoint) < 1)
        {
            nextPoint = GetRandomPoint();
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }

    private Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
