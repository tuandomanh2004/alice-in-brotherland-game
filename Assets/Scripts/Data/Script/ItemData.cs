using UnityEngine;
[CreateAssetMenu(menuName = "ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private bool isDetected = false;
     public string GetInteractionPrompt() => interactionPrompt;
    public string GetItemName() => itemName;
    public string GetItemDescription() => itemDescription ;     
}
