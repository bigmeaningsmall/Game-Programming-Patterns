
using UnityEngine;
using System;

public class SubjectWithParameters : MonoBehaviour
{
    // now carries an int and a string
    public event Action<int, string> ThingHappened;
    
    public int numberToSend = 10;
    public string messageToSend = "Hello from SubjectWithParameters";

    void Start()
    {
        DoThing();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DoThing();
    }

    public void DoThing()
    {
        // pass the parameters when raising the event
        ThingHappened?.Invoke(numberToSend, messageToSend);
    }
}