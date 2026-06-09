using UnityEngine;

public class HunterShooter : MonoBehaviour
{
    public LayerMask obstacleLayer;

    public GameObject bulletPrefab;

    public Transform firePoint;

    public float fireRate = 2f;

    public float detectionRange = 8f;

    public float rotateSpeed = 10f;

    private Transform player;

    void Awake()
    {
        GameObject playerObj =
            GameObject.FindGameObjectWithTag(
                "Player"
            );

        if (playerObj != null)
        {
            player =
                playerObj.transform;
        }
    }

    void Start()
    {
        InvokeRepeating(
            nameof(Shoot),
            1f,
            fireRate
        );
    }

    void Update()
    {
        AimAtPlayer();
    }

    void AimAtPlayer()
    {
        if (player == null)
            return;

        float yDifference =
            player.position.y -
            firePoint.position.y;

        // Limitar cuánto apunta arriba/abajo
        float yAngle =
            Mathf.Clamp(
                yDifference * 15f,
                -10f,
                25f
            );

        // Derecha
        if (
            player.position.x >
            transform.position.x
        )
        {
            firePoint.localRotation =
                Quaternion.Euler(
                    0,
                    0,
                    yAngle
                );
        }
        // Izquierda
        else
        {
            firePoint.localRotation =
                Quaternion.Euler(
                    0,
                    0,
                    180f + yAngle
                );
        }
    }

    public bool CanSeePlayer()
    {
        if (player == null)
            return false;

        float distance =
            Vector2.Distance(
                transform.position,
                player.position
            );

        if (distance > detectionRange)
            return false;

        Vector2 direction =
            (
                player.position -
                transform.position
            ).normalized;

        RaycastHit2D[] hits =
            Physics2D.RaycastAll(
                transform.position,
                direction,
                detectionRange
            );

        foreach (
            RaycastHit2D hit
            in hits
        )
        {
            // Ignorar al propio hunter
            if (
                hit.collider.gameObject
                == gameObject
            )
            {
                continue;
            }

            // Si ve al player
            if (
                hit.collider.CompareTag(
                    "Player"
                )
            )
            {
                return true;
            }

            // Si encuentra obstáculo primero
            if (
                hit.collider.CompareTag(
                    "Obstacle"
                )
            )
            {
                return false;
            }
        }

        return false;
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

        if (!CanSeePlayer())
            return;

        Vector2 direction =
            (
                player.position -
                firePoint.position
            ).normalized;

        RaycastHit2D hit =
            Physics2D.Raycast(
                firePoint.position,
                direction,
                detectionRange,
                obstacleLayer
            );

        // Si chocó algo, no dispara
        if (hit.collider != null)
        {
            return;
        }

        Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );
    }
}