using UnityEngine;

public class HunterShooter : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    public float fireRate = 2f;
    public Transform player;
    public float detectionRange = 8f;

    void Start()
    {
        InvokeRepeating(
            "Shoot",
            1f,
            fireRate
        );
    }
    void Awake()
    {
        player =
            GameObject.FindGameObjectWithTag("Player")
            .transform;
    }

    void Shoot()
    {
        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                transform.position,
                player.position
            );

        if (distance <= detectionRange)
        {
            Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
            );
        }
    }
}