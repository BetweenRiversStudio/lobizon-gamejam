using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(
            Vector2.left *
            speed *
            Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(
        Collider2D collision
    )
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(15);
            }

            Destroy(gameObject);
        }
    }
}