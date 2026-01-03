using UnityEngine;

public class DDOL : MonoBehaviour
{
    public static GameManager gameManager ; 
    public static CursorManager cursorManager ;
    public static CameraSwitcher camManager ;
    public static DDOL Instance { get; private set;}    
    void Awake(){ 
        if(Instance != null  && Instance != this)
        {
            Destroy(gameObject) ; 
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject) ; 
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
