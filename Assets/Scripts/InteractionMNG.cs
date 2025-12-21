using UnityEngine;

public class InteractionMNG : MonoBehaviour
{
    [SerializeField] private IInteractionBehaviors[] interactionBehaviors ; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        interactionBehaviors = GetComponents<IInteractionBehaviors>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HoverEnter()
    {
        foreach(var behavior in interactionBehaviors)
        {
           behavior.HoverEnter();   
        }
    }
    public void HoverExit()
    {
        foreach(var behavior in interactionBehaviors)
        {
           behavior.HoverExit();   
        }
    }
}
