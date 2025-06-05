using UnityEngine;

public class ARScaleAndMove : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;
    private Vector3 lastTouchPos;
    private bool isMoving = false;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 delta = Input.GetTouch(0).deltaPosition;
                transform.position += new Vector3(delta.x, 0, delta.y) * Time.deltaTime * 0.01f;
            }
        }

        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            if (t0.phase == TouchPhase.Began || t1.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(t0.position, t1.position);
                initialScale = transform.localScale;
            }
            else if (t0.phase == TouchPhase.Moved || t1.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(t0.position, t1.position);
                float scaleFactor = currentDistance / initialDistance;

                transform.localScale = initialScale * scaleFactor;
            }
        }
    }
}
