using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    [SerializeField] private List<InteractiveItem> items ; 
    [SerializeField] private int currentIndex ; 
    void Start()
    { 
        items = GetComponentsInChildren<InteractiveItem>().ToList();
        HideItem() ; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayItem(ItemSlot slot)
    {
        var slotData = slot.GetItemData() ; 
        if(currentIndex != slot.GetIndex())
        {
            currentIndex = slot.GetIndex() ; 
            foreach(var item in items)
            {
                var itemData = item.GetItemData() ; 
                if(itemData.itemName == slotData.itemName)
                {
                    HideItem() ; 
                    item.gameObject.SetActive(true);  
                }
            }

        }
        else
        {
            HideItem();     
        }
    }
    public void HideItem()
    {
        foreach(var item in items)
        {
            item.gameObject.SetActive(false) ; 
        }  
    } 
}
