using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class TooltipBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData item;
    [SerializeField] private TooltipUIController tooltipUI;
    [SerializeField] private Vector3 offset;
    public void Awake()
    {
       // item = GetComponent<InteractiveItem>();
    } 
    public void HoverEnter()
    {
        tooltipUI.SetUIData(item.itemName, item.itemDescription);
        tooltipUI.SetUIPanelPosition(transform.position,offset);
        tooltipUI.Show();
    }

    public void HoverExit()
    {
        tooltipUI.Hide();
    }
}
