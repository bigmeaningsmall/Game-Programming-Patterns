using UnityEngine;

// Another type of enemy - the Orc
public class MyOrc : MyEnemy
{
    public override void Attack()
    {
        Debug.Log("The Orc charges forward!");
    }
}
