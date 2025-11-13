using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Table : MonoBehaviour, IInteractable
{
    [SerializeField] private CameraSwitcher camSW;
  //  [SerializeField] private UnityEvent onInteraction; 
    [SerializeField] private bool isFocused = false;
    void Start()
    {
     //   onInteraction.Invoke();
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
}
// learn how to set up and switch multiple cameras with cinemachine 
// Create crosshair
// show UI voi interactprompt khi raycast quet den
// outline object 
// handle interact()
