using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [Header("Look")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float verticalRotation ;
    [SerializeField] private float horizontalRotation ;
    [SerializeField] private float minAngle , maxAngle;
    [Header("Reference")]
    [SerializeField] private Transform player ; 
    void Start()
    {

    }
    void Update()
    {
        HandleRotate();
    }
    void HandleRotate()
    {
        float mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime ;
        float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        Debug.Log($"mouseX : {mouseXInput} , mouseY : {mouseYInput}") ; 
        verticalRotation -= mouseYInput ;  // Di chuyển dọc lên xuống theo chuột
        verticalRotation = Mathf.Clamp(verticalRotation , minAngle, maxAngle) ;
        transform.localRotation =  Quaternion.Euler(verticalRotation,0f , 0f) ; 
        player.Rotate(mouseXInput*Vector3.up) ; 
    }
}
