using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneDetectionController : MonoBehaviour
{
    enum PlaneDetectionMode { None, Horizontal };
    [SerializeField]
    private PlaneDetectionMode detectEverything = PlaneDetectionMode.Horizontal;
    public ARPlaneManager arPlaneManager;
    bool detectPlanes = true;


    public void TrackingToggle()
    {
        detectPlanes = !detectPlanes;
        arPlaneManager.requestedDetectionMode = (UnityEngine.XR.ARSubsystems.PlaneDetectionMode)(detectPlanes ? detectEverything : PlaneDetectionMode.None);
    }
}