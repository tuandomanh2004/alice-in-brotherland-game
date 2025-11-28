using UnityEngine;

public class Card : InteractionManager  
{
    public override void Start()
    {
        base.Start();
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        Debug.Log("Selected :" + gameObject.name) ; 
    }
}
