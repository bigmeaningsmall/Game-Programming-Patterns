using UnityEngine;

// The factory is responsible for creating enemies in the scene
// It hides the logic of which prefab to spawn from the rest of the game
public class MyEnemyFactory : MonoBehaviour
{
    [Header("Assign enemy prefabs in the Inspector")]
    public GameObject goblinPrefab;
    public GameObject orcPrefab;

    // This method creates (spawns) an enemy at the given position
    public MyEnemy CreateEnemy(MyEnemyType type, Vector3 position)
    {
        GameObject prefabToSpawn = null;

        // Choose which prefab to spawn based on the enemy type
        switch (type)
        {
            case MyEnemyType.Goblin:
                prefabToSpawn = goblinPrefab;
                break;

            case MyEnemyType.Orc:
                prefabToSpawn = orcPrefab;
                break;

            default:
                Debug.LogWarning("Unknown enemy type: " + type);
                return null;
        }

        // Spawn the prefab in the scene
        GameObject enemyObject = Instantiate(prefabToSpawn, position, Quaternion.identity);

        // Get the MyEnemy component from the spawned prefab
        MyEnemy enemy = enemyObject.GetComponent<MyEnemy>();

        // Return the enemy instance to the caller
        return enemy;
    }
}