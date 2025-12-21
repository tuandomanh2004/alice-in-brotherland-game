using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField]private string interactionPrompt;
    [SerializeField] protected bool isDetected = false;
    [SerializeField] private bool  isFocus = false;
    void Start()
    {
        
    }
    void Update()
    {

    }
    public string GetInteractionPrompt() => interactionPrompt;
    public bool IsFocus() => isFocus;
    public void Focus()
    {
        isFocus = !isFocus ; 
    }
}
