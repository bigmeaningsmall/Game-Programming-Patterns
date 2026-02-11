using UnityEngine;

public class MyAgent_StateController : MonoBehaviour
{
    public MyAgent agent;
    public Transform moveTarget;

    private void Update()
    {
        if (agent == null) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            agent.ChangeState(new State_Idle(agent));
            Debug.Log("[Controller] 1 → Idle");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            agent.ChangeState(new State_MoveToTarget(agent, moveTarget));
            Debug.Log("[Controller] 2 → MoveToTarget");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            agent.ChangeState(new State_Patrol(agent));
            Debug.Log("[Controller] 3 → Patrol");
        }
    }
}