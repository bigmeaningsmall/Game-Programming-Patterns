using UnityEngine;

// A specific type of enemy - the Goblin
public class MyGoblin : MyEnemy
{
    public override void Attack()
    {
        Debug.Log("The Goblin swings his club!");
    }
}