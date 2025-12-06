using TMPro;
using UnityEngine;

[RequireComponent(typeof(OutlineBehavior))]
public class InteractionManager : InteractiveItem
{
    [SerializeField] protected OutlineBehavior outline; 
    [SerializeField] protected TooltipBehavior tooltip; 
    [SerializeField] protected LiftHoverBehavior liftHover;
    [SerializeField] protected HandleSelectionBehavior handleSelection ; 
    public virtual void Start()
    {
        outline = GetComponent<OutlineBehavior>() ; 
    }

    void Update()
    {

    }
    public void Outline()
    {
        outline?.SetOutline(isDetected);
    }

    public virtual void SetInteractPrompt()
    {

    }
    public virtual string GetItemDescription()
    {
        return "" ; 
    } 
    public void Tooltip()
    {
        tooltip?.SetTooltip(this.isDetected, this.name ,this.GetItemDescription(),this.transform.position) ; 
    }
    public void Lift(bool isHover)
    {
        liftHover?.SetHover(isHover);
    }
    void OnMouseDown()
    {
        handleSelection?.HandleClick() ; 
    }
}
