using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private GameObject selectedUI;
    [SerializeField] private bool isFull, isSelected;
    public bool IsFull() => isFull;
    void Start()
    {
        SetUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FillItem(ItemData item)
    {
        isFull = true;
        SetUI();

        itemImage.sprite = item.itemIcon;
        itemName.text = item.itemName;
    }
    public void SetUI()
    {
        itemImage.gameObject.SetActive(isFull);
        itemName.gameObject.SetActive(isFull);
        selectedUI.SetActive(isSelected);
    }
}
