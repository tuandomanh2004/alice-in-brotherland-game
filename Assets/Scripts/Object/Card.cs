using UnityEngine;
using UnityEngine.EventSystems;

public class Card : InteractionManager
{
    public override void Start()
    {
        base.Start();
        liftHoverItem = GetComponent<LiftHoverBehavior>();
    }
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Selected :" + gameObject.name);
    }
    public override string GetItemDescription()
    {
        return "This is " + gameObject.name;
    }
}
