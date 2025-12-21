using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HandleSelectionBehavior : MonoBehaviour 
{
    [SerializeField] private CameraTarget wall;
    [SerializeField] private Transform camPos;
 //   [SerializeField] private SetDissolveBehavior wallDissolve ;  
    public void HandleClick()
    {
        Debug.Log("Handle OK") ; 
        SetUpCameraFocus();
     //   wallDissolve.ApplyDissolve() ; 
    }
    private void SetUpCameraFocus()
    {
        CameraSwitcher.Instance.wallFocusCamera.LookAt = wall.TrackingTarget ; 
        CameraSwitcher.Instance.wallFocusCamera.transform.position = camPos.position ; 
        CameraSwitcher.Instance.SwitchCamera(CameraSwitcher.Instance.GetWallCamera());
    }
}
