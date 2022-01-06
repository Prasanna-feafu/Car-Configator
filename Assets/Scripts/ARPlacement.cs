using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARPlacement : MonoBehaviour
{
    public PlaneDetectionController trackingToggle;
    public ARSession planeController;
    public ARRaycastManager raycastManager;
    public List<ARRaycastHit> rayHitResults;
    public GameObject placementParent;
    public Pose currentPose;
    public bool spawnControl;

    void Start()
    {
        rayHitResults = new List<ARRaycastHit>();
        currentPose = new Pose();
    }

    void Update()
    {
        if(!spawnControl)
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, rayHitResults, TrackableType.PlaneWithinPolygon))
            {
                if (rayHitResults.Count > 0)
                {
                    if (!placementParent.activeSelf)
                    {
                        placementParent.SetActive(true);
                    }
                    placementParent.transform.SetPositionAndRotation(rayHitResults[0].pose.position, rayHitResults[0].pose.rotation);
                    spawnControl = true;
                    trackingToggle.TrackingToggle();
                }
            }
        }
    }
}