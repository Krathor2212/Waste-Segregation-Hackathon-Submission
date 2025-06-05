using UnityEngine;

public class MockClassifier : MonoBehaviour
{
    public enum WasteType { Plastic, Metal, Organic }
    public WasteType assignedType = WasteType.Plastic; // Default for inspector

    void Start()
    {
        // Assign tag based on manually set category
        gameObject.tag = assignedType.ToString();

        Debug.Log($"{name} is classified as {assignedType} and tagged as '{gameObject.tag}'");
    }
}
