using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ApplyForceExample : MonoBehaviour
{
    public UnityEngine.Vector3 mousePos;
    void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(null, UnityEngine.Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.None; 
    }
    void Update()
    {
        Debug.Log(Input.mousePosition);
    }
    public UnityEngine.Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }
}
