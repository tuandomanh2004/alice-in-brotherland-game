using UnityEngine;
using UnityEngine.EventSystems;

public class Card : InteractionManager
{
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("Selected :" + gameObject.name) ; 
    }
    public override string GetItemDescription()
    {
        return "This is " + gameObject.name ;
    }
}
