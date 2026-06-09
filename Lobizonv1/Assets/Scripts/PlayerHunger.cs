using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHunger : MonoBehaviour
{
    public float hunger = 100f;

    public float hungerDrain = 5f;

    public Slider hungerBar;

    private bool isDead = false;

    void Update()
    {
        if (isDead)
            return;

        hunger -=
            hungerDrain *
            Time.deltaTime;

        hunger =
            Mathf.Clamp(
                hunger,
                0,
                100
            );

        hungerBar.value =
            hunger;

        if (hunger <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log(
            "El Lobizón murió de hambre"
        );

        DeathManager.instance
    .ShowDeath(
        "Murió de hambre"
    );
    }

    public void Eat(
        float foodAmount
    )
    {
        hunger += foodAmount;

        hunger =
            Mathf.Clamp(
                hunger,
                0,
                100
            );

        Debug.Log(
            "Comió. Hambre actual: "
            + hunger
        );
    }

    public void AddHunger(
        float amount
    )
    {
        hunger += amount;

        hunger =
            Mathf.Clamp(
                hunger,
                0,
                100
            );

        hungerBar.value =
            hunger;

        Debug.Log(
            "Hambre recuperada: "
            + hunger
        );
    }
}