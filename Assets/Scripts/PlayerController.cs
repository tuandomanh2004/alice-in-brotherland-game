using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;
    [SerializeField] private UnityEngine.Vector3 moveDir;
    [SerializeField] private float playerSpeed = 2.0f , moveValue;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        moveValue = Input.GetAxis("Vertical");
        moveDir = transform.forward * moveValue;
        if (moveValue != 0)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("moveValue", moveValue); 
            controller.Move(moveDir * playerSpeed * Time.deltaTime);
        }
        else anim.SetBool("isMoving", false); 
    }
}
