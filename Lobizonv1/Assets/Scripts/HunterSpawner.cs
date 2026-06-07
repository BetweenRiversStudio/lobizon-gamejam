using UnityEngine;

public class HunterSpawner : MonoBehaviour
{
    public GameObject hunterPrefab;

    public float spawnTime = 10f;

    void Start()
    {
        InvokeRepeating(
            "SpawnHunter",
            2f,
            spawnTime
        );
    }

    void SpawnHunter()
    {
        Instantiate(
            hunterPrefab,
            transform.position,
            Quaternion.identity
        );

        Debug.Log("Cazador spawneado");
    }
}
