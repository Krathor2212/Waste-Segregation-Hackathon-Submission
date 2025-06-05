using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("WasteSegregationSimulation"); // 🔁 Replace with your actual main scene name
    }
}
