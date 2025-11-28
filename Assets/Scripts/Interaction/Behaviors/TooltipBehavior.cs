using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipBehavior : MonoBehaviour
{
    [SerializeField] GameObject tooltipPanel;
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] TextMeshProUGUI itemDescriptionText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTooltip(bool isShow, string itemName, string itemDescription)
    {
        if (isShow)
        {
            itemNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
        }
        tooltipPanel.SetActive(isShow);
    }
}
