using UnityEngine;
using UnityEngine.Events;

// Define serializable UnityEvent subclasses for types Unity can show in Inspector
[System.Serializable] public class FloatEvent  : UnityEvent<float>  {}
[System.Serializable] public class IntEvent    : UnityEvent<int>    {}
[System.Serializable] public class BoolEvent   : UnityEvent<bool>   {}
[System.Serializable] public class StringEvent : UnityEvent<string> {}

public class EventSender_WithParams : MonoBehaviour
{
    [Header("Editor-wired, typed events")]
    [Space(10)]
    public FloatEvent onFloatEvent;
    public IntEvent onIntEvent;
    public BoolEvent onBoolEvent;
    public StringEvent onStringEvent;

    private float progress = 0f;
    private int counter = 0;
    private bool toggle = false;
    string msg = "Hello from UnityEvents!";
    
    void Update()
    {
        // Float
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log($"Sender:  float = {progress:0.00}");
            onFloatEvent?.Invoke(progress);
        }

        // Int
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log($"Sender:  int = {counter}");
            onIntEvent?.Invoke(counter);
        }

        // Bool
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log($"Sender:  bool = {toggle}");
            onBoolEvent?.Invoke(toggle);
        }

        // String
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log($"Sender:  string = \"{msg}\"");
            onStringEvent?.Invoke(msg);
        }
    }
}