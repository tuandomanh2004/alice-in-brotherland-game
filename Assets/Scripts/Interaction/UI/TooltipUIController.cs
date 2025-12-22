using TMPro;
using UnityEngine;

public class TooltipUIController : MonoBehaviour
{
    [SerializeField] private GameObject panelUI;
    [SerializeField] private TextMeshProUGUI titleUI;
    [SerializeField] private TextMeshProUGUI descriptionUI;
    public void Show()
    {
        panelUI.SetActive(true);
    }
    public void Hide()
    {
        panelUI.SetActive(false);
    }
    public void SetUIData(string title, string description)
    {
        this.titleUI.text = title;
        this.descriptionUI.text = description;
    }
    public void SetUIPanelPosition(Vector3 objectPosition, Vector3 offset)
    {
        if (panelUI.activeSelf)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition) + offset;
            panelUI.transform.position = screenPosition;
        }
    }
}
