using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwitcher : MonoBehaviour
{
    public enum PlayerCameraType
    {
        FirstPersonCamera,
        ThirdPersonCamera
    }
    public static PlayerCameraType camType {get ; private set ; }    
    [SerializeField] private bool isSwitching = false;
    [SerializeField] public CinemachineCamera playerCamera, firstPersonCamera, thirdPersonCamera;
    [SerializeField] public CinemachineCamera itemFocusCamera;
    [SerializeField] public CinemachineCamera wallFocusCamera;
    [SerializeField] private CinemachineCamera[] cameras;
    [SaveDuringPlay] private const int HIGHEST_PRIORITY = 10, DEFAULT_VAL = 1;
    void Awake()
    {
    }
    void Start()
    {
    }

    void Update()
    {
        ChangeCamera();
    }
    public CinemachineCamera GetItemCamera() => itemFocusCamera;
    public CinemachineCamera GetPlayerCamera() => playerCamera;
    public CinemachineCamera GetWallCamera() => wallFocusCamera;
    public void SetUpCamera(CinemachineCamera cam)
    {
        isSwitching = !isSwitching;
        if (isSwitching)
        {
            SwitchCamera(cam);
        }
        else
        {
            ResetCamera();
        }
    }
    public void SwitchCamera(CinemachineCamera cam)
    {
        for (int index = 0; index < cameras.Length; index++)
        {
            if (cameras[index].name == cam.name)
            {
                cameras[index].Priority = HIGHEST_PRIORITY;
            }
            else
            {
                cameras[index].Priority = index;
            }
        }
    }
    public void ResetCamera()
    {
        for (int index = 0; index < cameras.Length; index++)
        {
            if (cameras[index] == playerCamera)
            {
                cameras[index].Priority = HIGHEST_PRIORITY;
            }
            else
            {
                cameras[index].Priority = index;
            }
        }
    }
    private void ChangeCamera() // For test
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerCamera.Priority = HIGHEST_PRIORITY;
            itemFocusCamera.Priority = DEFAULT_VAL;
            wallFocusCamera.Priority = DEFAULT_VAL + 1;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            itemFocusCamera.Priority = HIGHEST_PRIORITY;
            playerCamera.Priority = DEFAULT_VAL;
            wallFocusCamera.Priority = DEFAULT_VAL + 1;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            wallFocusCamera.Priority = HIGHEST_PRIORITY;
            itemFocusCamera.Priority = DEFAULT_VAL;
            playerCamera.Priority = DEFAULT_VAL + 1;
        }
    }
    public void SetPlayerCameraType(string sceneName)
    {
        switch (sceneName)
        {
            case "main":
                 camType = PlayerCameraType.ThirdPersonCamera;
                 break  ;
            default:
                 camType = PlayerCameraType.FirstPersonCamera;
                 break ; 
        }
    }
    public CinemachineCamera GetPlayerCameraByState()
    {
        switch (camType)
        {
            case PlayerCameraType.FirstPersonCamera:
                return firstPersonCamera;
            case PlayerCameraType.ThirdPersonCamera:
                return thirdPersonCamera;
            default:
                return null;
        }
    }
    public void InitializeCameras(string sceneName)
    {
        SetPlayerCameraType(sceneName);
        playerCamera = GetPlayerCameraByState();
        if (playerCamera != null)
        {
            playerCamera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
            SwitchCamera(playerCamera);
        }
    }
    // player spawn ở main room -> 3rd camera ( default )
    // player spawn ở map -> 1st camera -> Set 1st camera priority > 3rd camera priority
}
