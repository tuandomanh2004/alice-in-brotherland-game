using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HandleSelectionBehavior : MonoBehaviour
{
    [SerializeField] private CameraSwitcher camSW;
    [SerializeField] private CinemachineCamera wallCamera;
   [SerializeField] private CameraTarget wall;
    [SerializeField] private Transform camPos;
    [SerializeField] private OpenTheWall wallPivot;
    [SerializeField] private float delayAfterTransition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HandleClick()
    {
        SetUpCameraFocus();
        StartCoroutine(MakeRotation(delayAfterTransition)) ; 
    }
    private void SetUpCameraFocus()
    {
        wallCamera.LookAt = wall.TrackingTarget;
        wallCamera.transform.position = camPos.position;
        camSW.SwitchCamera(wallCamera);
    }
    // private void MakeRotation()
    // {
    //     wallPivot.DownTheWall() ;
    // }
    IEnumerator MakeRotation(float duration)
    {
        yield return new WaitForSeconds(duration);
        wallPivot.DownTheWall() ;
    }
}
