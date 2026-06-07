using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(
            gameObject.name +
            " recibió daño"
        );

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            PlayerHunger hunger =
                player.GetComponent<PlayerHunger>();

            if (hunger != null)
            {
                hunger.AddHunger(50f);
            }
        }

        Destroy(gameObject);
    }
}