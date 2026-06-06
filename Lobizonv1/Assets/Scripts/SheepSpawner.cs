using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public GameObject sheepPrefab;

    public Transform[] spawnPoints;

    public float spawnTime = 5f;

    void Start()
    {
        InvokeRepeating(
            "SpawnSheep",
            1f,
            spawnTime
        );
    }

    void SpawnSheep()
    {
        int randomIndex =
            Random.Range(0, spawnPoints.Length);

        Transform spawnPoint =
            spawnPoints[randomIndex];

        Instantiate(
            sheepPrefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }
}
