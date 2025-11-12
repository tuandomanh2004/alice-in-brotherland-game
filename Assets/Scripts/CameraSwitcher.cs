using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineCamera itemFocusCamera;
    void Start()
    {
    }

    void Update()
    {
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
    // 
}
