using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HandleSelectionBehavior : MonoBehaviour 
{
    [SerializeField] private CameraTarget wall;
    [SerializeField] private Transform camPos;
    public void HandleClick()
    {
        Debug.Log("Handle OK") ; 
        SetUpCameraFocus();
    }
    private void SetUpCameraFocus()
    {
        CameraSwitcher.Instance.wallFocusCamera.LookAt = wall.TrackingTarget ; 
        CameraSwitcher.Instance.wallFocusCamera.transform.position = camPos.position ; 
        CameraSwitcher.Instance.SwitchCamera(CameraSwitcher.Instance.GetWallCamera());
    }
}
