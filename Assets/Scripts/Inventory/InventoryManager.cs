using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> itemSlots;
    void Start()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>().ToList();
    }

    // Update is called once per frame
    void Update()
    {

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
}
