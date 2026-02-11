using UnityEngine;

public class Observer : MonoBehaviour
{
    //[SerializeField] private Subject subjectToObserve;
    
    private void OnEnable()
    {           
        //subjectToObserve.ThingHappened += this.OnThingHappened;
        Subject.ThingHappened += this.OnThingHappened;
        
    }
    private void OnDisable()
    {
        //subjectToObserve.ThingHappened -= this.OnThingHappened;
        Subject.ThingHappened += this.OnThingHappened;
    }
    
    private void OnThingHappened()
    {
        // Respond to the event
        Debug.Log("Observer responds");
    }

}
