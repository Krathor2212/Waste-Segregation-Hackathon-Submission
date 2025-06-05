using UnityEngine;

public class RollerRotation : MonoBehaviour
{
    public float rotationSpeed = 300f; // Adjust as needed
    public Vector3 rotationAxis = Vector3.left; 

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
