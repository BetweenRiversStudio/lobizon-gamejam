using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    public float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;
    public LayerMask foodLayer;
    public float foodAmount = 20f;

    void Update()
    {
        if (
    Input.GetKeyDown(KeyCode.E)
    && Time.time >= nextAttackTime
)
        {
            Attack();

            nextAttackTime =
                Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies =
            Physics2D.OverlapCircleAll(
                attackPoint.position,
                attackRange,
                enemyLayers
            );

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>()
                ?.TakeDamage(attackDamage);
        }

        Debug.Log("Mordida!");

        Collider2D[] hitFood =
    Physics2D.OverlapCircleAll(
        attackPoint.position,
        attackRange,
        foodLayer
    );

        foreach (Collider2D food in hitFood)
        {
            PlayerHunger hunger =
                GetComponent<PlayerHunger>();

            if (hunger != null)
            {
                hunger.Eat(foodAmount);
            }

            Destroy(food.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange
        );
    }
}
