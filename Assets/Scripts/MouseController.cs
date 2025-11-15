using System.Numerics;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Camera focusItemCamera ; 
    [SerializeField] private float distance = 3.0f ; 
    [SerializeField] private LayerMask layer ;
    [SerializeField] private IInteractable item ; 
    void Start()
    {
        focusItemCamera = Camera.main ; 
    }

    // Update is called once per frame
    void Update()
    {
        MouseHover() ; 
    }
    void MouseHover()
    {
        Ray ray = focusItemCamera.ScreenPointToRay(Input.mousePosition) ;
        if(Physics.Raycast(ray,out RaycastHit hit, distance, layer))
        {
            if(hit.collider.TryGetComponent(out IInteractable obj))
            {
                item = obj ; 
                item.Interact();
            }
        }
        // Debug.DrawRay(position.origin, position.direction *1.0f , Color.red) ; 
        // Debug.Log(position) ; 
    }
}
