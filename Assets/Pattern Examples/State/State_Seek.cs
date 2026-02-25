using UnityEngine;

/// <summary>
/// Seek behaviour — a step up from MoveToTarget.
/// Instead of smooth-damping directly to the target position,
/// we calculate a *desired velocity* toward the target and
/// steer the agent's current velocity toward it.
///
/// This gives a more natural, momentum-based chase that
/// can tune with maxSpeed and steerStrength.
/// </summary>
public class State_Seek : IState
{
    private readonly MyAgent agent;
    private readonly Transform target;

    private Vector3 currentVelocity;

    // How hard the agent can steer toward the target each frame
    private const float SteerStrength = 8f;

    public State_Seek(MyAgent agent, Transform target)
    {
        this.agent = agent;
        this.target = target;
    }

    public void Enter()
    {
        agent.SetColour(Color.yellow);
        currentVelocity = Vector3.zero;
        Debug.Log("[State_Seek] Enter");
    }

    public void Tick()
    {
        if (target == null) return;

        Seek();
    }

    public void Exit()
    {
        Debug.Log("[State_Seek] Exit");
    }

    private void Seek()
    {
        Transform t = agent.transform;
        float maxSpeed = agent.moveSpeed;

        // 1. Desired velocity — full speed toward target
        Vector3 desiredVelocity = (target.position - t.position).normalized * maxSpeed;

        // 2. Steering — nudge current velocity toward desired velocity
        currentVelocity = Vector3.MoveTowards(
            currentVelocity,
            desiredVelocity,
            SteerStrength * Time.deltaTime
        );

        // 3. Apply movement
        t.position += currentVelocity * Time.deltaTime;

        // 4. Face the direction we're moving
        if (currentVelocity.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(currentVelocity);
            t.rotation = Quaternion.Slerp(t.rotation, targetRot, agent.turnSpeed * Time.deltaTime);
        }
    }
}