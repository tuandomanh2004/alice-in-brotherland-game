using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TeleportBehavior : MonoBehaviour
{
    [SerializeField] private string mapName ;
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
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           MANAGER.Instance.sceneManager.LoadScene(mapName);
        }
    }
    public void CloseTeleport()
    {
        objectBox.isTrigger = false;
    }
}
