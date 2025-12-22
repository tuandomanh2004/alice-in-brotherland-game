using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Interactions : MonoBehaviour
{
    [SerializeField] private List<IInteractable> interactableList ;
    [SerializeField] private UnityEvent OnInteract ;
    void Awake()
    {
        interactableList = GetComponents<IInteractable>().ToList() ;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HoverEnter()
    {
        foreach(var interactable in interactableList)
        {
            interactable.HoverEnter() ; 
        }
    }
    public void HoverExit()
    {
        foreach(var interactable in interactableList)
        {
            interactable.HoverExit() ; 
        }
    }
    public void Interact()
    {
        OnInteract?.Invoke() ; 
    }
}
