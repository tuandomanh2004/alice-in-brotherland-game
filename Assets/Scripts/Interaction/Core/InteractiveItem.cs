using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    [SerializeField]private string interactionPrompt;
    [SerializeField] protected bool isDetected = false;
    void Start()
    {
        
    }
    void Update()
    {

    }
    public string GetInteractionPrompt() => interactionPrompt;
}
