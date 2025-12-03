using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private bool isSwitching = false;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineCamera itemFocusCamera;
    [SerializeField] private CinemachineCamera wallFocusCamera;
    [SerializeField] private CinemachineCamera[] cameras;
    [SaveDuringPlay] private const int HIGHEST_PRIORITY = 10 , DEFAULT_VAL = 1 ;
    void Start()
    {
    }

    void Update()
    {
        ChangeCamera() ; 
    }
    public CinemachineCamera GetItemCamera() => itemFocusCamera ; 
    public CinemachineCamera GetPlayerCamera() => playerCamera ; 
    public CinemachineCamera GetWallCamera() => wallFocusCamera ;  
    public void SetUpCamera(CinemachineCamera cam)
    {
        isSwitching = !isSwitching;
        if (isSwitching)
        {
            SwitchCamera(cam) ; 
        }
        else
        {
            ResetCamera() ;
        }
    }
    public void SwitchCamera(CinemachineCamera cam)
    {
       for(int index = 0 ; index < cameras.Length ; index++)
        { 
            if(cameras[index].name == cam.name)
            {
                cameras[index].Priority = HIGHEST_PRIORITY ;
            }
            else
            {
                cameras[index].Priority = index ;
            }
        }
    }
    public void ResetCamera()
    {
        for(int index = 0 ; index < cameras.Length ; index++)
        {
            if(cameras[index] == playerCamera)
            {
                cameras[index].Priority = HIGHEST_PRIORITY ;
            }
            else
            {
                cameras[index].Priority = index ;
            }
        }
    }
    private void ChangeCamera() // For test
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerCamera.Priority = HIGHEST_PRIORITY ;
            itemFocusCamera.Priority= DEFAULT_VAL ;
            wallFocusCamera.Priority=  DEFAULT_VAL + 1;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            itemFocusCamera.Priority= HIGHEST_PRIORITY ;
            playerCamera.Priority = DEFAULT_VAL ;
            wallFocusCamera.Priority=  DEFAULT_VAL + 1;
        }
        else if(Input.GetKeyDown(KeyCode.Z))
        {
            wallFocusCamera.Priority = HIGHEST_PRIORITY ;
            itemFocusCamera.Priority= DEFAULT_VAL ;
            playerCamera.Priority = DEFAULT_VAL + 1 ;
        }
    }
}
