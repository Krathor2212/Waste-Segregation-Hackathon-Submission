using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float beltSpeed = 2f;

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null)
        {
            // Apply force or velocity to simulate belt motion
            rb.velocity = transform.forward * beltSpeed + new Vector3(0, rb.velocity.y, 0);
        }
    }
}
