using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private ItemData itemData ; 
    [SerializeField] private int slotIndex ;
    [SerializeField] private UnityEngine.UI.Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private GameObject selectedUI;
    [SerializeField] private bool isFull, isSelected;
    public bool IsFull() => isFull;
    public int GetIndex() => slotIndex;
    public ItemData GetItemData() => itemData;

    void Start()
    {
        SetItemUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FillItem(ItemData item)
    {
        itemData = item ; 
        isFull = true;
        SetItemUI();

        itemImage.sprite = itemData.itemIcon;
        itemName.text = itemData.itemName;
    }
    public void SetIndex(int index)
    {
        slotIndex = index ; 
    }
    public void SetItemUI()
    {
        itemImage.gameObject.SetActive(isFull);
        itemName.gameObject.SetActive(isFull);
    }
    public void SetSelectedUI(bool isSelected)
    {
        this.isSelected = isSelected;
        selectedUI.SetActive(this.isSelected) ; 
    }
    public void SetSelectedUI()
    {
        isSelected = !isSelected;
        selectedUI.SetActive(isSelected) ; 
    }
}
