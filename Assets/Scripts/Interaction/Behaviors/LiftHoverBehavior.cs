using UnityEngine;

public class LiftHoverBehavior : MonoBehaviour , IInteractable
{
    [SerializeField] private float liftHeight;
    [SerializeField] private Vector3 originalPos ; 
    [SerializeField] private Vector3 targetPos ;
    [SerializeField] private float speed;
    [SerializeField] private bool isHover = false;
    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Lift();
    }
    public void Lift()
    {
        if (isHover)
        {
            targetPos = originalPos  + liftHeight*Vector3.up ;
            
        }
        else
        {
            targetPos = originalPos ;

        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, speed * Time.deltaTime);
    }
    public void SetHover(bool isHover)
    {
        this.isHover = isHover;
    }

    public void HoverEnter()
    {
        SetHover(true) ; 
    }

    public void HoverExit()
    {
        SetHover(false) ; 
    }
}
