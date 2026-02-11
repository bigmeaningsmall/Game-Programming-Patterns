using UnityEngine;

// Demonstrates how to use the factory interactively
public class FactoryController : MonoBehaviour
{
    [Header("Assign the factory in the Inspector")]
    public MyEnemyFactory factory;

    [Header("Spawn Settings")]
    public float spawnDistance = 2f; // distance between spawned enemies

    private int spawnCount = 0; // keep track of how many enemies have been spawned

    private void Update()
    {
        // Spawn a Goblin when pressing G
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnEnemy(MyEnemyType.Goblin);
        }

        // Spawn an Orc when pressing O
        if (Input.GetKeyDown(KeyCode.O))
        {
            SpawnEnemy(MyEnemyType.Orc);
        }

        // Clear all enemies when pressing C
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearEnemies();
        }
    }

    private void SpawnEnemy(MyEnemyType type)
    {
        // Each enemy spawns further along the X axis so we can see them separately
        Vector3 spawnPos = new Vector3(spawnCount * spawnDistance, 0, 0);
        MyEnemy newEnemy = factory.CreateEnemy(type, spawnPos);

        if (newEnemy != null)
        {
            newEnemy.Attack();
            spawnCount++;
        }
    }

    private void ClearEnemies()
    {
        // Find all active enemies in the scene and destroy them
        MyEnemy[] allEnemies = FindObjectsOfType<MyEnemy>();
        foreach (MyEnemy enemy in allEnemies)
        {
            Destroy(enemy.gameObject);
        }

        spawnCount = 0;
        Debug.Log("All enemies cleared.");
    }
}