using TMPro;
using UnityEngine;

public class ShowInteractionPrompt : MonoBehaviour , IInteractable
{
    [SerializeField] private InteractiveItem item ;
    [SerializeField] private TextMeshProUGUI interactionText ;
    void Start()
    {
        item = GetComponent<InteractiveItem>();
        Debug.Log(item) ; 
    }
    public void HoverEnter()
    {
        ShowInteractionText() ;
    }

    public void HoverExit()
    {
        HideInteractionText() ; 
    }
    public void ShowInteractionText()
    {
        interactionText.text = item.GetInteractionPrompt();
        interactionText.enabled = true ;  
    }
    public void HideInteractionText()
    {
        interactionText.text = "" ; 
        interactionText.enabled = false ; 
    }
}
