using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private bool isSwitching = false;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineCamera itemFocusCamera;
    [SerializeField] private CinemachineCamera wallFocusCamera;
    [SaveDuringPlay] private const int HIGHEST_PRIORITY = 10 ;
    void Start()
    {
    }

    void Update()
    {
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
}
