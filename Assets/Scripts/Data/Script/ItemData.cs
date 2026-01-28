using UnityEngine;
[CreateAssetMenu(menuName = "ItemObject", order = 1)]
public class ItemData : ScriptableObject
{
    public string interactionPrompt;
    public string itemName;
    public string itemDescription;  
}
