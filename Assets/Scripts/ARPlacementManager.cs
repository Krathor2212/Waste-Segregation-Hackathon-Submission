using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARPlacementManager : MonoBehaviour
{
    public GameObject objectToPlace;

    private ARRaycastManager raycastManager;
    private GameObject placedObject;
    private bool isPlaced = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (isPlaced) return;

        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began) return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            // For test: place a cube
            placedObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            placedObject.transform.position = hitPose.position + new Vector3(0, 0.1f, 0);
            placedObject.transform.localScale = Vector3.one * 0.2f;

            // To test your prefab instead, replace above with:
            // placedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
            // placedObject.transform.localScale = Vector3.one;
            // placedObject.transform.position += new Vector3(0, 0.05f, 0);

            isPlaced = true;
            Debug.Log("✅ Object placed");
        }
    }
}
