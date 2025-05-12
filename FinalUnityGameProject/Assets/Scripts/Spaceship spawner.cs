using UnityEngine;

public class SpaceshipSpawner : MonoBehaviour
{
    public GameObject spaceshipPrefab;
    public float spawnInterval = 30f;
    public float spawnHeight = 30f;
    public float mapBounds = 50f;
    private float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnSpaceship();
            timer = 0f;
        }
    }
    void SpawnSpaceship()
    {
        Vector3 startPos = GetRandomEdgePosition();
        Vector3 endPos = GetRandomEdgePosition();
        while (Vector3.Distance(startPos, endPos) < 10f)
        {
            endPos = GetRandomEdgePosition();
        }
        Vector3 direction = (endPos - startPos).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        Instantiate(spaceshipPrefab, startPos, rotation);
    }
    Vector3 GetRandomEdgePosition()
    {
        int edge = Random.Range(0, 4);
        float x = 0, z = 0;
        switch (edge)
        {
            case 0: 
                x = -mapBounds;
                z = Random.Range(-mapBounds, mapBounds);
                break;
            case 1: 
                x = mapBounds;
                z = Random.Range(-mapBounds, mapBounds);
                break;
            case 2: 
                x = Random.Range(-mapBounds, mapBounds);
                z = mapBounds;
                break;
            case 3: 
                x = Random.Range(-mapBounds, mapBounds);
                z = -mapBounds;
                break;
        }
        return new Vector3(x, spawnHeight, z);
    }
}