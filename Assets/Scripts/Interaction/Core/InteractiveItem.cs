using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField]private string interactionPrompt;
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] protected bool isDetected = false;
    [SerializeField] private bool  isFocus = false;
    void Start()
    {
        
    }
    void Update()
    {

    }
    public string GetInteractionPrompt() => interactionPrompt;
    public string GetItemName() => itemName;
    public string GetItemDescription() => itemDescription ;     
    public bool IsFocus() => isFocus;
    public void Focus()
    {
        isFocus = !isFocus ; 
    }
}
