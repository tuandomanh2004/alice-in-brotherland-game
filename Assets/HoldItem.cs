using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    [SerializeField] private List<InteractiveItem> items ; 
    [SerializeField] private GameObject currentItem ; 
    [SerializeField] private int currentIndex ; 
    void Start()
    { 
        items = GetComponentsInChildren<InteractiveItem>().ToList();
        HideItem() ; 
    }

    public void DisplayItem(ItemSlot slot)
    {
        var slotData = slot.GetItemData();
        int slotIndex = slot.GetIndex();
        
        foreach (InteractiveItem item in items)
        {
            if (item.GetItemData().itemName == slotData.itemName)
            {
                SelectItem(item.gameObject, slotIndex);
                return;
            }
        }
    }

    private void SelectItem(GameObject item, int slotIndex)
    {
        // Item hiện tại rỗng thì gán và out
        if (currentItem == null)
        {
            currentItem = item;
            currentIndex = slotIndex;
            currentItem.SetActive(true) ; 
        }

        // Chọn 1 cùng item slot thì đảo trạng thái hiển thị
        else if (currentIndex == slotIndex)
        {
            currentItem.SetActive(!currentItem.activeSelf);
        }

        // Chọn item khác với slot hiện tại thì tắt này bật kia
        else
        {
            currentItem.SetActive(false);
            currentItem = item;
            currentIndex = slotIndex;
            currentItem.SetActive(true);
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
