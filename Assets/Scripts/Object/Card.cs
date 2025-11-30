using UnityEngine;
using UnityEngine.EventSystems;

public class Card : InteractionManager
{
    [SerializeField] private string cardDescription ; 
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
        return "Path Of " + cardDescription;
    }
}
