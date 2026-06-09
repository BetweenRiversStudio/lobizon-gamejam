using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private HunterShooter shooter;

    public float minDistance = 5f;
    public float maxDistance = 7f;

    private Transform player;

    private Rigidbody2D rb;

    void Start()
    {
        shooter =
    GetComponent<HunterShooter>();
        player =
            GameObject
            .FindGameObjectWithTag("Player")
            .transform;

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                transform.position,
                player.position
            );
        if (
    shooter != null
)
        {
            Debug.Log(
                gameObject.name +
                " ve jugador: " +
                shooter.CanSeePlayer()
            );

            if (!shooter.CanSeePlayer())
            {
                rb.linearVelocity =
                    new Vector2(
                        0,
                        rb.linearVelocity.y
                    );

                return;
            }
        }

        Vector2 movement =
            Vector2.zero;

        // Muy lejos → acercarse
        if (distance > maxDistance)
        {
            movement =
                (
                    player.position -
                    transform.position
                ).normalized;
        }

        // Muy cerca → alejarse
        else if (distance < minDistance)
        {
            movement =
                (
                    transform.position -
                    player.position
                ).normalized;
        }

        // Mantener solo movimiento horizontal
        movement.y = 0;

        rb.linearVelocity =
            new Vector2(
                movement.x *
                moveSpeed,
                rb.linearVelocity.y
            );

        Flip();
    }

    void Flip()
    {
        if (player == null)
            return;

        Vector3 scale =
            transform.localScale;

        if (
            player.position.x >
            transform.position.x
        )
        {
            scale.x =
                Mathf.Abs(scale.x);
        }
        else
        {
            scale.x =
                -Mathf.Abs(scale.x);
        }

        transform.localScale =
            scale;
    }
}
