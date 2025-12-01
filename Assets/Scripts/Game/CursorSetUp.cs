using UnityEngine;

public class CursorSetUp : MonoBehaviour
{
    [SerializeField] private bool isVisible = false ;
    void Awake()
    {
        Cursor.visible = isVisible;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUpCursor()
    {
        isVisible = !isVisible ; 
        if (isVisible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(null, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked ; 
        }
    }
}
