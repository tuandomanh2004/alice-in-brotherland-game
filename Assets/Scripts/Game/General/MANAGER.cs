using UnityEngine;

public class MANAGER : MonoBehaviour
{
    public GameManager gameManager;
    public CursorManager cursorManager;
    public CameraSwitcher camManager;
    public SceneMNG sceneManager ;  
    public SpawnManager spawnManager;
    public static MANAGER Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
