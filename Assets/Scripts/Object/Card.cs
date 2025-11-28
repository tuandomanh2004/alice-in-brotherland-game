using UnityEngine;

public class Card : InteractiveItem
{
    public override void Start()
    {
        base.Start();
    }
    void Update()
    {
        
    }
    public override void Interact()
    {
        base.Interact();
    }
    public override void Outline()
    {
        base.Outline();
    }
    public override void ItemDetected(bool condition)
    {
        base.ItemDetected(condition);
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name) ; 
    }
}
