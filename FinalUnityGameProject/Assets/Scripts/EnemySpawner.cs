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
            print("Enemy prefab is missing");
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
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                randomPos.y = 0;
                GameObject enemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);
                
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.spawner = this;
                }
                currentEnemies++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void EnemyDied()
    {
        currentEnemies = Mathf.Max(0, currentEnemies - 1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}