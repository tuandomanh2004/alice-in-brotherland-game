using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private List<KeyCode> slotKeyCodes;
    [SerializeField] private int currentIndex;
    [SerializeField] private HoldItem itemHolder;
    void Start()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>().ToList();
    }

    void Update()
    {
        SelectItem();
    }
    public void AddItem(ItemData item)
    {
        foreach (var slot in itemSlots)
        {
            if (!slot.IsFull())
            {
                slot.FillItem(item);
                return;
            }
        }
    }
    public void SelectItem()
    {
        for (int index = 0; index < slotKeyCodes.Count; index++)
        {
            if (Input.GetKeyDown(slotKeyCodes[index]))
            {
                if (!itemSlots[index].IsFull()) return;

                // bấm cùng 1 ô item thì đổi ngược trạng thái hiện tại
                if(currentIndex == index)
                {
                    itemSlots[index].SetSelectedUI() ; 
                }

                // bấm ô khác thì tắt ô này bật ô kia
                else
                {
                    itemSlots[index].SetSelectedUI(false);
                    currentIndex = index ; 
                    itemSlots[currentIndex].SetSelectedUI(true) ; 
                }
                // itemHolder.DisplayItem(itemSlots[currentIndex]) ; 
            }
        }

    }
    void DeSelectAllSlots()
    {
        foreach (var slot in itemSlots)
        {
            slot.SetSelectedUI(false);
        }
    }

}
