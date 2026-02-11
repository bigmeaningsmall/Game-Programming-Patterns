using UnityEngine;

public class State_MoveToTarget : IState
{
    private readonly MyAgent agent;
    private readonly Transform target;
    private Vector3 velocity;

    public State_MoveToTarget(MyAgent agent, Transform target)
    {
        this.agent = agent;
        this.target = target;
    }

    public void Enter()
    {
        agent.SetColour(Color.green);
        velocity = Vector3.zero;
        Debug.Log("[State_MoveToTarget] Enter");
    }

    public void Tick()
    {
        if (target == null) return;

        MoveToTarget();
    }

    public void Exit()
    {
        Debug.Log("[State_MoveToTarget] Exit");
    }
    
    //logic
    private void MoveToTarget()
    {
        agent.transform.position = Vector3.SmoothDamp(
            agent.transform.position,
            target.position,
            ref velocity,
            agent.smoothTime,
            Mathf.Infinity,
            Time.deltaTime
        );

        Vector3 dir = target.position - agent.transform.position;
        if (dir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, targetRot, agent.turnSpeed * Time.deltaTime);
        }
    }
}