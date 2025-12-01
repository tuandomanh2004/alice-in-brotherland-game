using System;
using System.IO.Compression;
using System.Numerics;
using NUnit.Framework.Internal;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator anim;
    [SerializeField] private UnityEngine.Vector3 moveDir;
    [SerializeField] private float playerSpeed = 2.0f, verticalInput, horizontalInput, rotateSpeed = 5.0f;
    [SerializeField] private Transform cam;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private InteractionManager item; 
    public float distance = 10f;
    
    

    void Awake()
    {
       // detectionLayer = LayerMask.GetMask("ray"); 
    } 
    void Start()
    {
        InitializeComponent();
        //SetUpCursor(); 
    }

    void Update()
    {
        Move();
        UpdateAnimation();
        // DetectItem(); 
        // InteractWithItem() ; 
    }
    private void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        UnityEngine.Vector3 moveInput = (cam.forward * verticalInput) + (cam.right * horizontalInput); // Tạo vector di chuyển theo hướng cam và input
        moveInput.y = 0f; 
        moveDir = moveInput.normalized; // Chuẩn hóa vector thành độ lớn = 1 để nhất quán tốc độ di chuyển  
        if(moveDir != UnityEngine.Vector3.zero) // Nếu player chuyển động thì xoay theo vector di chuyển
        {
            UnityEngine.Quaternion desiredRotation = UnityEngine.Quaternion.LookRotation(moveDir, UnityEngine.Vector3.up); // tạo góc quay
            transform.rotation = UnityEngine.Quaternion.Lerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);  // tạo chuyển động quay
        }
        controller.Move(moveDir * playerSpeed * Time.deltaTime); // di chuyển theo vector
    }
    private void UpdateAnimation()
    {
        float moveAmount = Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput); // Check input di chuyển của player
        bool isMoving = moveAmount > 0;  
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("verticalMove", verticalInput);
        anim.SetFloat("horizontalMove", horizontalInput);
    }
    private void InitializeComponent() 
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main.transform;
    }
}
