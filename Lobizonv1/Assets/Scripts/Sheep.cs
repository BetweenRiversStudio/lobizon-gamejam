using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float foodValue = 30f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHunger playerHunger =
            collision.GetComponent<PlayerHunger>();

        if (playerHunger != null)
        {
            playerHunger.Eat(foodValue);

            Destroy(gameObject);
        }
    }
}