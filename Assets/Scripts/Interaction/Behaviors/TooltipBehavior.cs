using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(InteractiveItem))]
public class TooltipBehavior : MonoBehaviour, IInteractable
{
    // [SerializeField] private PanelSettings tooltipPanel;
    // [SerializeField] private TextMeshProUGUI itemNameText;
    // [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private InteractiveItem item;
    [SerializeField] private TooltipUIController tooltipUI;
    [SerializeField] private Vector3 offset;
    public void Awake()
    {
        item = GetComponent<InteractiveItem>();
    } 
    public void HoverEnter()
    {
        tooltipUI.SetUIData(item.GetItemName(), item.GetItemDescription());
        tooltipUI.SetUIPanelPosition(transform.position,offset);
        tooltipUI.Show();
    }

    public void HoverExit()
    {
        tooltipUI.Hide();
    }
}
