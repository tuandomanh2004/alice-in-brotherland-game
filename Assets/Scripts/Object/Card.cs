using UnityEngine;
using UnityEngine.EventSystems;

public class Card : InteractionManager
{
    [SerializeField] private string cardDescription ; 
    public override void Start()
    {
        base.Start();
        liftHover = GetComponent<LiftHoverBehavior>();
    }
    void Update()
    {

    }
    public override string GetItemDescription()
    {
        return "Path Of " + cardDescription;
    }
}
