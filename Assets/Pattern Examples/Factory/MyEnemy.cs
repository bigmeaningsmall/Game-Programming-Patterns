using UnityEngine;

// Base class for all enemies
// Defines common behaviour that all enemies will share
public abstract class MyEnemy : MonoBehaviour
{
    // Each enemy type will define its own attack behaviour
    public abstract void Attack();
}



