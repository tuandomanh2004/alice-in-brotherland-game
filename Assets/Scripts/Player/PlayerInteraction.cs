using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform focusCam;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private Interactions it;
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
        InteractWithItem();
    }
    private void DetectItem()
    {
        Ray ray = new Ray(focusCam.position, focusCam.forward); // tạo tia  
        if (Physics.Raycast(ray, out RaycastHit hit, distance, detectionLayer)) // check tia bắn trúng obj 
        {

            if (hit.collider.TryGetComponent(out Interactions obj))
            {
                Debug.Log($"hit {hit.collider.gameObject.name}");
                it = obj;
                it.HoverEnter();
            }
        }
        else // Không quét vào object nữa thì tắt outline,UI của object hiện tại và trả null
        {
            if (it != null)
            {
                it.HoverExit();
                it = null;
            }

        }
    }
    private void InteractWithItem() // Xử lí input tương tác từ player
    {
        if (Input.GetKeyDown(KeyCode.E) && it != null)
        {
            it.Interact();
        }
    }
}
