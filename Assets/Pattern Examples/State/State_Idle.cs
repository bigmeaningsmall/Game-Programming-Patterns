using UnityEngine;

public class State_Idle : IState
{
    private readonly MyAgent agent;
    public State_Idle(MyAgent agent) { this.agent = agent; }

    public void Enter()
    {
        agent.SetColour(Color.white);
        Debug.Log("[State_Idle] Enter");
    }

    public void Tick(){
        /* idle */
        Debug.Log("[State_Idle] Tick");
        
    }

    public void Exit()
    {
        Debug.Log("[State_Idle] Exit");
    }
}