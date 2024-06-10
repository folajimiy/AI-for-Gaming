public class AttackState : FSMState
{
    public AttackState(GameObject npc, Transform player, FSM fsm) : base(npc, player, fsm) { }

    public override void Enter()
    {
        Debug.Log("Entering Attack State");
    }

    public override void Execute()
    {
        // Implement attack logic here

        if (Vector3.Distance(npc.transform.position, player.position) > 2)
        {
            fsm.ChangeState(State.Chase);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Attack State");
    }
}
