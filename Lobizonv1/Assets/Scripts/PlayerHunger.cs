using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    public float hunger = 100f;
    public float hungerDrain = 5f;

    public Slider hungerBar;

    void Update()
    {
        hunger -= hungerDrain * Time.deltaTime;

        hunger = Mathf.Clamp(hunger, 0, 100);

        hungerBar.value = hunger;

        if (hunger <= 0)
        {
            Debug.Log("El Lobizón murió de hambre");
        }
    }

    public void Eat(float foodAmount)
    {
        hunger += foodAmount;

        hunger = Mathf.Clamp(hunger, 0, 100);

        Debug.Log("Comió. Hambre actual: " + hunger);
    }
    public void AddHunger(float amount)
    {
        hunger += amount;

        hunger = Mathf.Clamp(hunger, 0, 100);

        hungerBar.value = hunger;

        Debug.Log(
            "Hambre recuperada: " +
            hunger
        );
    }
}