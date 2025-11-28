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

    // Update is called once per frame
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
            Debug.Log((Vector2)itemPosition) ; 
        }
        tooltipPanel.SetActive(isShow);
    }
    public void SetPanelPosition(Vector3 itemPosition)
    {
        if (gameObject.activeSelf)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(itemPosition) + offset;
            // RectTransformUtility.ScreenPointToLocalPointInRectangle(
            //     tooltipPanel.transform.parent as RectTransform,
            //     screenPanelPosition,
            //     null,
            //     out Vector2 localPoint
            // );
            tooltipPanel.transform.position = screenPos;
        }

    }
}
