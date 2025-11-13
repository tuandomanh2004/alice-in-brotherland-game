using NUnit.Framework;
using Unity.Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Table : MonoBehaviour, IInteractable
{
    [SerializeField] private CameraSwitcher camSW;
    //  [SerializeField] private UnityEvent onInteraction; 
    [SerializeField] private bool isFocused = false ;
    [SerializeField] private Outline outlineItem; 
    void Start()
    {
        //   onInteraction.Invoke();
        outlineItem = GameObject.Find("Table").GetComponent<Outline>(); 
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
        }
        else
        {
            camSW.ResetCamera();
        }
    }
    public void GetInteractPrompt()
    {
        Debug.Log("Press [E] to interact with " + gameObject.name);
    }
    public void Outline(bool isDetected)
    {
        outlineItem.enabled = isDetected;
    }
    public void TurnOffOutline()
    {
        outlineItem.enabled = false; 
    }
}
// display outline when  ray scan table
// show UI voi interactprompt khi raycast quet den
// show mouse cursor in focus camera 
// outline card player choose

