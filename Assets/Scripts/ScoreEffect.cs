using UnityEngine;
using TMPro;

public class ScoreEffect : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public CanvasGroup canvasGroup;
    public float floatSpeed = 30f;
    public float fadeDuration = 0.5f;

    private float lifetime = 1.2f;

    void Update()
    {
        // Move upward
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

        // Fade out
        lifetime -= Time.deltaTime;
        if (lifetime < fadeDuration)
        {
            canvasGroup.alpha = lifetime / fadeDuration;
        }

        // Destroy after lifetime
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetText(string text, Color color)
    {
        scoreText.text = text;
        scoreText.color = color;
    }
}
