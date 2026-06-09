using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject tutorialTextObject;
    public TextMeshProUGUI tutorialText;

    [TextArea]
    public string message;

    public float duration = 4f;

    private bool activated = false;

    private void OnTriggerEnter2D(
        Collider2D collision
    )
    {
        if (
            collision.CompareTag("Player")
            && !activated
        )
        {
            activated = true;

            StartCoroutine(
                ShowTutorial()
            );
        }
    }

    IEnumerator ShowTutorial()
    {
        tutorialTextObject.SetActive(true);

        tutorialText.text = message;

        yield return new WaitForSeconds(
            duration
        );

        tutorialTextObject.SetActive(false);
    }
}
