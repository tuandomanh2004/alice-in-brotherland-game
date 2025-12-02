using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private bool isSwitching = false;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineCamera itemFocusCamera;
    [SerializeField] private CinemachineCamera wallFocusCamera;
    [SaveDuringPlay] private const int HIGHEST_PRIORITY = 10 , DEFAULT_VAL = 1 ;
    void Start()
    {
    }

    void Update()
    {
        ChangeCamera() ; 
    }
    public void SetUpCamera()
    {
        isSwitching = !isSwitching;
        if (isSwitching)
        {
            SwitchCamera() ; 
        }
        else
        {
            ResetCamera() ;
        }
    }
    public void SwitchCamera()
    {
        itemFocusCamera.Priority = 2;
        playerCamera.Priority = 1;
    }
    public void ResetCamera()
    {
        itemFocusCamera.Priority = 1;
        playerCamera.Priority = 2;
    }
    private void ChangeCamera()
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
