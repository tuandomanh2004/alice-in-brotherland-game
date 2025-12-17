using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HandleSelectionBehavior : MonoBehaviour
{
    [SerializeField] private CameraSwitcher camSW;
    [SerializeField] private CinemachineCamera wallCamera;
   [SerializeField] private CameraTarget wall;
    [SerializeField] private Transform camPos;
    [SerializeField] private SetDissolveBehavior wallPivot;
    [SerializeField] private float delayAfterTransition;

    void Start()
    {

    }
    void Update()
    {

    }
    public void HandleClick()
    {
        GameManager.Instance.state = GameManager.GameState.Loading ; 
        SetUpCameraFocus();
        StartCoroutine(MakeRotation(delayAfterTransition)) ; 
    }
    private void SetUpCameraFocus()
    {
        wallCamera.LookAt = wall.TrackingTarget;
        wallCamera.transform.position = camPos.position;
        camSW.SwitchCamera(wallCamera);
    }
    IEnumerator MakeRotation(float duration)
    {
        yield return new WaitForSeconds(duration);
        wallPivot.Dissolve() ;
    }
}
