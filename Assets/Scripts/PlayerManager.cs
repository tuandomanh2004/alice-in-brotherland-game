using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   [SerializeField] private SpawnManager playerSpawner;
    [SerializeField] private PlayerControllerManager playerControllerManager;
    void Awake()
    {
        playerSpawner = GetComponent<SpawnManager>();
        playerControllerManager = GetComponent<PlayerControllerManager>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnPlayer(string sceneName)
    {
        playerSpawner.SpawnPlayer(sceneName) ; 
    }
    public void SetControllerMode()
    {
        playerControllerManager.SetControllerMode() ; 
    }
}
