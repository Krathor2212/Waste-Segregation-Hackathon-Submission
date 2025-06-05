using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera mainCamera;
    private int draggingFingerId = -1;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouse();
#elif UNITY_ANDROID || UNITY_IOS
        HandleTouch();
#endif
    }

    void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
            {
                isDragging = true;
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = mainCamera.WorldToScreenPoint(transform.position).z;
                Vector3 worldPoint = mainCamera.ScreenToWorldPoint(mousePos);
                offset = transform.position - worldPoint;

                if (TryGetComponent<Rigidbody>(out var rb))
                    rb.isKinematic = true;
            }
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 worldPoint = mainCamera.ScreenToWorldPoint(mousePos);
            transform.position = worldPoint + offset;
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            if (TryGetComponent<Rigidbody>(out var rb))
                rb.isKinematic = false;
        }
    }

    void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Vector3 touchPos = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.WorldToScreenPoint(transform.position).z));

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Ray ray = mainCamera.ScreenPointToRay(touch.position);
                        if (Physics.Raycast(ray, out RaycastHit hit))
                        {
                            if (hit.transform == transform)
                            {
                                isDragging = true;
                                draggingFingerId = touch.fingerId;
                                offset = transform.position - touchPos;

                                if (TryGetComponent<Rigidbody>(out var rb))
                                    rb.isKinematic = true;
                            }
                        }
                        break;

                    case TouchPhase.Moved:
                        if (isDragging && touch.fingerId == draggingFingerId)
                        {
                            transform.position = touchPos + offset;
                        }
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        if (isDragging && touch.fingerId == draggingFingerId)
                        {
                            isDragging = false;
                            draggingFingerId = -1;

                            if (TryGetComponent<Rigidbody>(out var rb))
                                rb.isKinematic = false;
                        }
                        break;
                }
            }
        }
    }
}
