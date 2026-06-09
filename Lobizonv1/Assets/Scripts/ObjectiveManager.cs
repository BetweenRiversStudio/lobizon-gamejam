using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    private bool objective2Done = false;
    private bool objective3Done = false;

    void Update()
    {
        string sceneName =
            SceneManager
                .GetActiveScene()
                .name;

        // Campo
        if (sceneName == "Countryside")
        {
            if (
                GameClock.CurrentTime < 60f
            )
            {
                objectiveText.text =
                    "🌙 La noche ha comenzado, sal a cazar.";
            }
            else
            {
                objectiveText.text =
                    "🐑 No hay más ovejas, busca el pueblo.";
            }
        }

        // Pueblo
        if (sceneName == "City")
        {
            objectiveText.text =
                "⚔️ Avanza por el pueblo y enfréntate a Martín Fierro.";
        }
    }
}