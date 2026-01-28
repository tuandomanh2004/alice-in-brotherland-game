using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractiveItem))] 
public class ShowInteractionPrompt : MonoBehaviour , IInteractable
{
    [SerializeField] private InteractiveItem item ;
    [SerializeField] private TextMeshProUGUI interactionText ;
    void Start()
    {
        if(item == null)
        {
            item = GetComponent<InteractiveItem>();
        }
        if(interactionText == null)
        {
            interactionText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>() ; 
        }
      //  Debug.Log(item) ; 
    }
    public void HoverEnter()
    {
        if (!item.IsFocus())
        {
            ShowInteractionText() ;
        }
        else
        {
            HideInteractionText() ; 
        }   
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
