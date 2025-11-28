using UnityEngine;

public class Card : InteractionManager  
{
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("Selected :" + gameObject.name) ; 
    }
}
