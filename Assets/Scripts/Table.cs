using UnityEngine;

public class Table : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interact()
    {
        Debug.Log("Table Interacted : " + gameObject.name);
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
