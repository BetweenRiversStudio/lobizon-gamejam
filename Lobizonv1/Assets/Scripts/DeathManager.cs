using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject deathPanel;

    public TextMeshProUGUI reasonText;

    public static DeathManager instance;

    void Awake()
    {
        instance = this;
    }

    public void ShowDeath(
        string reason
    )
    {
        Time.timeScale = 0f;

        deathPanel.SetActive(
            true
        );

        reasonText.text =
            "Motivo: " +
            reason;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        GameClock.CurrentTime = 0f;

        Destroy(
            FindObjectOfType<GameClock>()
            .gameObject
        );

        SceneManager.LoadScene(
            "Countryside"
        );
    }
}