using NUnit.Framework;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    void SetInteractPrompt();
    void Outline() ;
    bool IsDetected(bool condition) ; 
}
