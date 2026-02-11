using UnityEngine;

public class SingletonUserA : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            Debug.Log("[UserA] Using Singleton");
            Singleton.Instance.IncrementCounter(); 
        }
    }
}