using Unity.Cinemachine;
using UnityEngine;

public class HandleSelectionBehavior : MonoBehaviour
{
    [SerializeField] CameraSwitcher camSW ; 
    [SerializeField] CinemachineCamera wallCamera ;
    [SerializeField] CameraTarget wall ;
    [SerializeField] Transform camPos ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleClick()
    { 
        wallCamera.LookAt = wall.TrackingTarget ;
        wallCamera.transform.position = camPos.position ; 
        camSW.SwitchCamera(wallCamera);
    }
}
