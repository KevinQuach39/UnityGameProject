using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public float spawnRadius = 20f;
    public float spawnInterval = 5f;
    public int maxEnemies = 10;
    private int currentEnemies = 0;
    void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab is not assigned in the Inspector!");
            return;  
        }
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                if (enemyPrefab != null)
                {
                    Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                    randomPos.y = 0;
                    Instantiate(enemyPrefab, randomPos, Quaternion.identity);
                    currentEnemies++;
                }
                else
                {
                    print("Enemy Prefab is missing");
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
