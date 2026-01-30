using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Interactions : MonoBehaviour
{
    [SerializeField] private List<IInteractable> interactableList ;
    [SerializeField] private IPickupable pickupableItem ; 
    [SerializeField] private UnityEvent OnInteract ;
    void Awake()
    {
        interactableList = GetComponents<IInteractable>().ToList() ;
        pickupableItem = GetComponent<IPickupable>() ;
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
        // Ưu tiên pick up 
        if(pickupableItem != null)
        {
            pickupableItem.OnPickUp() ; 
            HoverExit() ; 
            return ; 
        }
        OnInteract?.Invoke() ; 
    }
}

// Press E -> Get item data -> Destroy object -> Add item into inventory -> Show UI