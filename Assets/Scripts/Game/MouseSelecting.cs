using System.Numerics;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class MouseSelecting : MonoBehaviour
{
    [SerializeField] private Camera focusItemCamera;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private InteractiveItem item;
    void Start()
    {
        focusItemCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MouseHover();
    }
    public void MouseHover() 
    {
        Ray ray = focusItemCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit hit, distance, layer))
        {
            if(hit.collider.TryGetComponent(out InteractiveItem obj))
            {
                item = obj ; 
                item.ItemDetected(true);
             //   Debug.Log(item.isDetected) ; 
//Debug.Log(obj.name) ; 
                item.Outline();
                
            }
        }
        else
        {
            if(item != null)
            {
                item.ItemDetected(false);
                item.Outline();
                item = null ;  
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 1.0f, Color.red);
      //  Debug.Log(ray);
    }
}
