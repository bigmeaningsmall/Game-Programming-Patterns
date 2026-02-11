using UnityEngine;

public class MyAgent : MonoBehaviour
{
    [Header("Visuals")]
    public Renderer rend; // assign in Inspector

    [Header("Movement")]
    public float moveSpeed = 1f;
    public float turnSpeed = 4f;
    public float smoothTime = 1.25f;

    [Header("Patrol")]
    public Vector3 patrolAOffset = new Vector3(-5, 0, 0);
    public Vector3 patrolBOffset = new Vector3(5, 0, 0);
    public float patrolSpeed = 1f;

    private IState currentState;

    private void Start()
    {
        if (rend == null)
            rend = GetComponent<Renderer>();

        ChangeState(new State_Idle(this));
    }

    private void Update()
    {
        currentState?.Tick();
    }

    public void ChangeState(IState next)
    {
        if (next == null) return;

        currentState?.Exit();
        currentState = next;

        Debug.Log($"[MyAgent] → {currentState.GetType().Name}");
        currentState.Enter();
    }

    public void SetColour(Color colour)
    {
        if (rend != null)
            rend.material.color = colour;
    }
}