using UnityEngine;
using UnityEngine.Events;

public class EventSender_NoParams : MonoBehaviour
{
    [Header("Editor-wired event (no parameters)")]
    public UnityEvent onTriggered;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Sender: Space pressed → Raising event!");
            onTriggered?.Invoke();
        }
    }
}