using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameClock : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    public float gameMinutesPerSecond = 5f;

    public float currentMinutes = 0f;

    public static float CurrentTime;

    private static GameClock instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject textObject =
            GameObject.Find("ClockText");

        if (textObject != null)
        {
            clockText =
                textObject.GetComponent<TextMeshProUGUI>();
        }
    }
    void Update()
    {
        currentMinutes +=
            gameMinutesPerSecond *
            Time.deltaTime;

        CurrentTime = currentMinutes;

        int hours =
            Mathf.FloorToInt(
                currentMinutes / 60
            );

        int minutes =
            Mathf.FloorToInt(
                currentMinutes % 60
            );

        clockText.text =
            hours.ToString("00") +
            ":" +
            minutes.ToString("00");
       
        if (currentMinutes >= 360f)
        {
            Debug.Log("Se hizo de día. Perdiste.");

            UnityEngine.SceneManagement
                .SceneManager
                .LoadScene(
                    UnityEngine.SceneManagement
                    .SceneManager
                    .GetActiveScene()
                    .name
                );
        }
    }
    public void SetMinimumTime(float minimumTime)
    {
        if (currentMinutes < minimumTime)
        {
            currentMinutes = minimumTime;
        }
    }
}
