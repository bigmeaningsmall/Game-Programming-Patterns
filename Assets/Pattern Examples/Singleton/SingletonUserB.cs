using UnityEngine;

public class SingletonUserB : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)){
            Debug.Log("[UserB] Using Singleton");
            Singleton.Instance.IncrementCounter(); 
        }
    }
}