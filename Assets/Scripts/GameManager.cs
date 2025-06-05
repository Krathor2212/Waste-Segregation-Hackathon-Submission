using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public GameObject scorePopupPrefab; // 🎯 Assign a prefab with TextMeshProUGUI
    public Transform popupSpawnPoint;   // 🎯 Top-right corner of the screen (set in Canvas)

    public void UpdateScore(int delta)
    {
        if (delta == 1)
        {
            score += 1;
            ShowPopup("+1", Color.green);
        }
        else if (delta == 0)
        {
            score -= 1;
            ShowPopup("-1", Color.red);
        }

        scoreText.text = "Score: " + score;
    }

    void ShowPopup(string text, Color color)
    {
        if (scorePopupPrefab && popupSpawnPoint)
        {
            GameObject popup = Instantiate(scorePopupPrefab, popupSpawnPoint.position, Quaternion.identity, popupSpawnPoint);
            TextMeshProUGUI popupText = popup.GetComponent<TextMeshProUGUI>();
            popupText.text = text;
            popupText.color = color;

            // Auto-destroy after a second
            Destroy(popup, 1f);
        }
    }
}
