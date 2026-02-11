using UnityEngine;

public class State_Patrol : IState
{
    private readonly MyAgent agent;
    private Vector3 start;
    private Vector3 velocity;

    public State_Patrol(MyAgent agent) { this.agent = agent; }

    public void Enter()
    {
        start = agent.transform.position;
        agent.SetColour(Color.cyan);
        Debug.Log("[State_Patrol] Enter");
    }

    public void Tick()
    {
        Patrol();
    }

    public void Exit()
    {
        Debug.Log("[State_Patrol] Exit");
    }
    
    //logic
    private void Patrol()
    {
        Vector3 a = start + agent.patrolAOffset;
        Vector3 b = start + agent.patrolBOffset;
        float t = Mathf.PingPong(Time.time * agent.patrolSpeed, 1f);
        Vector3 target = Vector3.Lerp(a, b, t);

        agent.transform.position = Vector3.SmoothDamp(
            agent.transform.position,
            target,
            ref velocity,
            agent.smoothTime,
            Mathf.Infinity,
            Time.deltaTime
        );

        Vector3 dir = target - agent.transform.position;
        if (dir.sqrMagnitude > 0.001f)
        {
            Quaternion toRot = Quaternion.LookRotation(dir);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, toRot, agent.turnSpeed * Time.deltaTime);
        }
    }
}