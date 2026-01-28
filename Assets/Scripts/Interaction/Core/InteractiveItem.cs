using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField] private ItemData itemData; 
    [SerializeField] private bool  isFocus = false;
    void Start()
    {
        
    }
    void Update()
    {

    }
    public bool IsFocus() => isFocus;
    public ItemData GetItemData() => itemData;
    public void Focus()
    {
        isFocus = !isFocus ; 
    }
}
