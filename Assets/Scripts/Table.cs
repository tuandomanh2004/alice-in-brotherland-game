using NUnit.Framework;
using TMPro;
using Unity.Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Table : MonoBehaviour, IInteractable
{
    [SerializeField] private CameraSwitcher camSW;
    //  [SerializeField] private UnityEvent onInteraction; 
    [SerializeField] private bool isFocused = false, isDetected = false;
    [SerializeField] private Outline outlineItem;
    [SerializeField] private TextMeshProUGUI interactionUI;
    void Start()
    {
        //   onInteraction.Invoke();
        outlineItem = GameObject.Find("Table").GetComponent<Outline>();
        interactionUI.text = "Press [E] to interact" ;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interact()
    {
        isFocused = !isFocused;
        if (isFocused)
        {
            camSW.SwitchCamera();
            interactionUI.enabled = !isDetected;
            camSW.SetUpCursor();
        }
        else
        {
            camSW.ResetCamera();
            interactionUI.enabled = isDetected;
        }
    }
    public void SetInteractPrompt()
    {
        if(!isFocused)
        {
            interactionUI.enabled = isDetected;
        }
        else
        {
            interactionUI.enabled = !isDetected;
        }
    }
    public void Outline()
    {
        outlineItem.enabled = isDetected;
    }
    public bool IsDetected(bool isDetected) => this.isDetected = isDetected;
}
// display outline whenever ray scan table - DONE
// show UI voi interactprompt khi raycast quet den - DONE 
// show mouse cursor in focus camera - DONE 
// make mouse controller class 
// outline card player choose

