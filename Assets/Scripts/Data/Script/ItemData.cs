using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "ItemObject", order = 1)]
public class ItemData : ScriptableObject
{
    public string interactionPrompt;
    public string itemName;
    public string itemDescription;  
    public Sprite itemIcon ; 
}

