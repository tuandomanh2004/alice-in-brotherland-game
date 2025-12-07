using UnityEngine;
using DG.Tweening;
public class OpenTheWall : MonoBehaviour
{

    [SerializeField] private Vector3 original, flip;
    [SerializeField] private bool isFlipped = false;
    [SerializeField] private float duration = 3f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Test() ; 
    }
    public void DownTheWall()
    {
        isFlipped = true;
        transform.DORotate(flip, duration);
    }
    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlipped = !isFlipped;
            transform.DORotate(isFlipped ? original : flip, duration);
        }
    }
}
