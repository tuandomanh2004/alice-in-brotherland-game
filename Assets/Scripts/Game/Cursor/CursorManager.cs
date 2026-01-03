using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private MouseSelecting mouseSelecting ; 
    [SerializeField] private CursorSetUp cursor ;
    void Awake()
    {
        mouseSelecting = GetComponent<MouseSelecting>();
        cursor = GetComponent<CursorSetUp>();
    } 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
