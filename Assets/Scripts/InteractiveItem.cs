using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public bool isDetected = false;
    public Outline outlineItem;

    public virtual void Interact()
    {

    }

    public virtual void ItemDetected(bool condition)
    {
        isDetected = condition;
    }

    public virtual void Outline()
    {
        outlineItem.enabled = isDetected;
    }

    public virtual void SetInteractPrompt()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        outlineItem = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
