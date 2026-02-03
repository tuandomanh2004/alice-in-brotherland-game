using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<ItemSlot> onItemSelected;
    [SerializeField] private List<ItemSlot> itemSlots;
    [SerializeField] private List<KeyCode> slotKeyCodes;
    [SerializeField] private int currentIndex;
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
                SetSelectedItemUI(itemSlots[index], index);
                onItemSelected.Invoke(itemSlots[currentIndex]);
                return;
            }
        }
    }
    void SetSelectedItemUI(ItemSlot itemSlotAtIndex, int index)
    {
        if (!itemSlotAtIndex.IsFull()) return;

        // bấm cùng 1 ô item thì đổi ngược trạng thái hiện tại
        if (currentIndex == index)
        {
            itemSlotAtIndex.SetSelectedUI();
        }

        // bấm ô khác thì tắt ô này bật ô kia
        else
        {
            itemSlotAtIndex.SetSelectedUI(false);
            currentIndex = index;
            itemSlotAtIndex.SetSelectedUI(true);
        }
    }
}
