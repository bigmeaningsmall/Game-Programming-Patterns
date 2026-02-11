using UnityEngine;

public class ObserverWithParameters : MonoBehaviour
{
    [SerializeField] SubjectWithParameters subject; // assign in Inspector

    void OnEnable()
    {
        subject.ThingHappened += HandleThing;
    }

    void OnDisable()
    {
        subject.ThingHappened -= HandleThing;
    }

    void HandleThing(int number, string message)
    {
        Debug.Log($"Received: {number}, {message}");
    }
}