using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HandleSelectionBehavior : MonoBehaviour 
{
    [SerializeField] private CameraTarget wall;
    [SerializeField] private Transform camPos;
    public void HandleClick()
    {
        SetUpCameraFocus();
    }
    private void SetUpCameraFocus()
    {
        MANAGER.Instance.camManager.wallFocusCamera.LookAt = wall.TrackingTarget; 
        MANAGER.Instance.camManager.wallFocusCamera.transform.position = camPos.position; 
        MANAGER.Instance.camManager.SwitchCamera(MANAGER.Instance.camManager.GetWallCamera());
    }
}
