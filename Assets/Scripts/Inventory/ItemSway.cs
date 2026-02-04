using UnityEngine;

public class ItemSway : MonoBehaviour
{
    [SerializeField] private float swaySpeed  ;
    [SerializeField] private float swayAmount ;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * swayAmount;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayAmount ; 

        // Make Rotation
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY , Vector3.right) ; 
        Quaternion rotationY = Quaternion.AngleAxis(mouseX , Vector3.up) ; 

        // Combine Rotation
        var targetRotation = rotationX * rotationY ; 
        transform.localRotation = Quaternion.Slerp(transform.localRotation , targetRotation , swaySpeed * Time.deltaTime) ; 
    }
}
