using UnityEngine;

public class CameraIntroMover : MonoBehaviour
{
    public Transform targetPosition; // Drag your CameraTargetPosition here
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

    private bool hasMoved = false;

    void Start()
    {
        hasMoved = true; // Trigger move on scene start
    }

    void Update()
    {
        if (!hasMoved) return;

        transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetPosition.rotation, Time.deltaTime * rotateSpeed);

        if (Vector3.Distance(transform.position, targetPosition.position) < 0.05f &&
            Quaternion.Angle(transform.rotation, targetPosition.rotation) < 1f)
        {
            hasMoved = false; // Stop after reaching the target
        }
    }
}
