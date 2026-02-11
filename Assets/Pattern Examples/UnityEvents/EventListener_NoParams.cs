using UnityEngine;

public class EventListener_NoParams : MonoBehaviour
{
    public void OnTriggered()
    {
        Debug.Log($"{gameObject.name} received the event!");
    }
}