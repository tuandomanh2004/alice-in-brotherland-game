using UnityEngine;

public class DisplayBookUI : MonoBehaviour , IUsable
{
    [SerializeField] private GameObject tutorialUI ;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        tutorialUI.SetActive(!tutorialUI.activeSelf) ; 
    }
}
