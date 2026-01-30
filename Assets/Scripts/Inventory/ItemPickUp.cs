using UnityEngine;

[RequireComponent(typeof(InteractiveItem))]
public class ItemPickUp : MonoBehaviour , IPickupable
{
    [SerializeField] private InventoryManager inventory ; 
    public ItemData GetItemData()
    {
        var itemData = GetComponent<InteractiveItem>().GetItemData() ; 
        return itemData ; 
    }

    public void OnPickUp()
    {
        var item = GetItemData() ; 
        inventory.AddItem(item) ; 
        Destroy(gameObject) ; 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = FindAnyObjectByType<InventoryManager>() ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
