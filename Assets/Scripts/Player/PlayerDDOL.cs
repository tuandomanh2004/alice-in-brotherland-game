using UnityEngine;

public class PlayerDDOL : MonoBehaviour
{
    private static PlayerDDOL instance ;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this ; 
            DontDestroyOnLoad(gameObject) ; 
        }
    } 
}
