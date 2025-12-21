using System.Numerics;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class MouseSelecting : MonoBehaviour
{
    [SerializeField] private Camera focusItemCamera;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Interactions item; 
    void Start()
    {
        focusItemCamera = Camera.main;
    }

    void Update()
    {

        MouseHover();
        MouseClick(); 
    }
    public void MouseHover()
    {
        Ray ray = focusItemCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, distance, layer))
        {
            if (hit.collider.TryGetComponent(out Interactions obj))
            {
                item = obj;
                item.HoverEnter(); 
                // item.ItemDetected(true);
                // item.Outline();
                // item.Tooltip();
                // item.Lift(true);
            }
            Debug.DrawRay(ray.origin, ray.direction * 1.0f, Color.red);
        }
        else
        {
            if (item != null)
            {
                // item.ItemDetected(false);
                // item.Outline();
                // item.Tooltip();
                // item.Lift(false);
                item.HoverExit() ; 
                item = null;
            }
        }
    }
    public void MouseClick()
    {
        if(Input.GetMouseButtonDown(0) && item != null)
        {
            Debug.Log("Click!") ; 
            item.Interact();
        }
    }
}
