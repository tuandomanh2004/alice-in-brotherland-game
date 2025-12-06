using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipBehavior : MonoBehaviour
{
    [SerializeField] private GameObject tooltipPanel;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private Vector3 offset;
    void Start()
    {
    }

    void Update()
    {

    }
    public void SetTooltip(bool isShow, string itemName, string itemDescription,Vector3 itemPosition)
    {
        if (isShow)
        {
            itemNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            SetPanelPosition(itemPosition);
        }
        tooltipPanel.SetActive(isShow);
    }
    public void SetPanelPosition(Vector3 itemPosition)
    {
        if (gameObject.activeSelf)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(itemPosition) + offset ;
            tooltipPanel.transform.position = screenPos;
        }

    }
}
