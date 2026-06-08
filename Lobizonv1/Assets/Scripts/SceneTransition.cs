using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameClock clock =
                FindFirstObjectByType<GameClock>();

            if (clock != null)
            {
                if (sceneToLoad == "Pueblo")
                {
                    clock.SetMinimumTime(120f);
                }

                if (sceneToLoad == "Boss")
                {
                    clock.SetMinimumTime(240f);
                }
            }

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}