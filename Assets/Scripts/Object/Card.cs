using UnityEngine;

public class Card : InteractiveItem,IClickableObject
{
    // Update is called once per frame
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

    public void OnMouseDown()
    {
        Debug.Log(gameObject.name) ; 
    }
}
