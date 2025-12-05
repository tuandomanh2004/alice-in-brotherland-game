using UnityEngine;
using DG.Tweening;
using UnityEngine.ProBuilder;
public class Test : MonoBehaviour
{
    [SerializeField] private Vector3 original , flip ;
    [SerializeField] private bool isFlipped = false ;  
    [SerializeField] private float duration = 3f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlipped = !isFlipped ;   
            transform.DORotate(isFlipped ? original : flip , duration) ; 
        }
    }
}
