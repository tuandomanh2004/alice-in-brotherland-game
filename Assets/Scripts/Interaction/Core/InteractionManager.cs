using TMPro;
using UnityEngine;

[RequireComponent(typeof(OutlineBehavior))]
public class InteractionManager : InteractiveItem
{
    [SerializeField] protected OutlineBehavior outlineItem; 
    [SerializeField] protected TooltipBehavior tooltipItem ; 
    public virtual void Start()
    {
        outlineItem = GetComponent<OutlineBehavior>() ; 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Outline()
    {
        outlineItem?.SetOutline(isDetected);
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
        tooltipItem.SetTooltip(this.isDetected, this.name ,this.GetItemDescription()) ; 
    }
}
