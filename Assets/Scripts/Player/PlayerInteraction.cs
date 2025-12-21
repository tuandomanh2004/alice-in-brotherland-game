using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform focusCam;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private InteractionManager item;
    [SerializeField] private Interactions it;
    [SerializeField] private CameraSwitcher camSw ;
    [SerializeField] private CursorSetUp cursorSU ; 
    [SerializeField] private float distance;
    void Awake()
    {
        detectionLayer = LayerMask.GetMask("ray");
        focusCam = Camera.main.transform;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DetectItem(); 
        InteractWithItem() ;
    }
     private void DetectItem()
    {
        Ray ray = new Ray(focusCam.position, focusCam.forward); // tạo tia  
        if (Physics.Raycast(ray, out RaycastHit hit, distance, detectionLayer)) // check tia bắn trúng obj 
        {
            if (hit.collider.TryGetComponent(out Interactions obj))
            {
                // item = obj;
                // item.ItemDetected(true) ; 
                // item.SetInteractPrompt();
                // item.Outline();  
                it = obj ; 
                it.HoverEnter() ; 
            }
        }
        else // Không quét vào object nữa thì tắt outline,UI của object hiện tại và trả null
        {
            if(it != null)
            {
                // item.ItemDetected(false) ; 
                // item.Outline(); 
                // item.SetInteractPrompt();
                // item = null;
                it.HoverExit() ; 
                it = null ;
            }
            
        }
    }
    private void InteractWithItem() // Xử lí input tương tác từ player
    {
        if (Input.GetKeyDown(KeyCode.E) && it != null )
        {
            // item.Interact();
            // camSw.SetUpCamera(camSw.GetItemCamera());
            // cursorSU.SetUpCursor() ; 
            it.Interact() ; 
        }
    }
}
