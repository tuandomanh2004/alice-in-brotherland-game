using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{
    [SerializeField] private BoxCollider objectBox;
    void Awake()
    {
        objectBox = GetComponent<BoxCollider>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenTeleport()
    {
        objectBox.isTrigger = true;
    }
    public void CloseTeleport()
    {
        objectBox.isTrigger = false;
    }
}
