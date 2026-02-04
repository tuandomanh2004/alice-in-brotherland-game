using UnityEngine;

public class PlayerControllerManager : MonoBehaviour
{
    [SerializeField] private Player1stController player1stController;
    [SerializeField] private Player3rdController player3rdController;

    void Awake()
    {
    }
    void Start()
    {
    }
    void Update()
    {

    }
    
    // Set controller based on camera type
    public void SetControllerMode()
    {
        bool is1stCam = CameraSwitcher.camType == CameraSwitcher.PlayerCameraType.FirstPersonCamera;
        if (is1stCam)
        {
            player1stController.enabled = true;
            player3rdController.enabled = false;
        }
        else
        {
            player3rdController.enabled = true;
            player1stController.enabled = false;
        }
    }
}
