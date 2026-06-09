using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    public float lifetime = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb =
            GetComponent<Rigidbody2D>();

        rb.linearVelocity =
            transform.right *
            speed;

        Destroy(
            gameObject,
            lifetime
        );
    }

    private void OnTriggerEnter2D(
    Collider2D collision
)
    {
        if (
            collision.CompareTag(
                "Player"
            )
        )
        {
            PlayerHealth playerHealth =
                collision.GetComponent<
                    PlayerHealth
                >();

            if (
                playerHealth != null
            )
            {
                playerHealth
                    .TakeDamage(15);
            }
        }

        // Destruir si toca algo
        // que no sea enemigo
        if (
            !collision.CompareTag(
                "Hunter"
            )
        )
        {
            Destroy(gameObject);
        }
    }
}