using UnityEngine;

public interface IPickupable
{
    ItemData GetItemData() ;
    void OnPickUp() ;  
}
