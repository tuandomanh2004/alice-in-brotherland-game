using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;
    [SerializeField] private UnityEngine.Vector3 moveDir;
    [SerializeField] private float playerSpeed = 2.0f , moveValue;

    void Start()
    {
        InitializeComponent(); 
    }

    void Update()
    {
        Move();
        UpdateAnimation(); 
    }
    private void Move()
    {
        moveValue = Input.GetAxis("Vertical");
        moveDir = transform.forward * moveValue;
        if (moveValue != 0)
        {
            controller.Move(moveDir * playerSpeed * Time.deltaTime);
        }
    }
    private void UpdateAnimation()
    {
        bool isMoving = moveValue != 0; 
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("moveValue", moveValue);
    }
    private void InitializeComponent()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>(); 
    }
}
