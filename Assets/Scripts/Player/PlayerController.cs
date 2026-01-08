using System;
using System.IO.Compression;
using System.Numerics;
using NUnit.Framework;
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
    public enum PlayerState
    {
        Locked,
        Free,
        None
    }
    public PlayerState playerState;

    [Header("-----ANIMATION AND CONTROLLER-----")]
    [SerializeField] protected CharacterController controller;
    [SerializeField] protected Animator anim;

    [Header("-----MOVEMENT PROPERTIES-----")]
    [SerializeField] protected UnityEngine.Vector3 moveDir;
    [SerializeField] protected float playerSpeed = 2.0f, verticalInput, horizontalInput, rotateSpeed = 5.0f;

    [Header("-----PLAYER CAMERA-----")]
    [SerializeField] protected Transform cam;

    protected virtual void Awake()
    {
        InitializeComponent();
    }
    void Start()
    {

    }

    protected virtual void Update()
    {
        if (playerState == PlayerState.Locked) return;
        Move();
        UpdateAnimation();

    }
    public virtual void SetState(PlayerState newState)
    {
        playerState = newState;
        if (playerState == PlayerState.Locked)
        {
            moveDir = UnityEngine.Vector3.zero;
            UpdateAnimation() ; 
        }
    }
    protected virtual void Move()
    {
        GetMovementInput();
        moveDir = HandleMovementInput();
        if (moveDir != UnityEngine.Vector3.zero) // Nếu player chuyển động thì xoay theo vector di chuyển
        {
            controller.Move(moveDir * playerSpeed * Time.deltaTime); // di chuyển theo vector
        }    
    }
    protected virtual void UpdateAnimation()
    {
        //     float moveAmount = Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput); // Check input di chuyển của player
        //     bool isMoving = moveAmount > 0;
        bool isMoving = moveDir != UnityEngine.Vector3.zero;
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("verticalMove", verticalInput);
        anim.SetFloat("horizontalMove", horizontalInput);
    }
    protected virtual void InitializeComponent()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main.transform;
        playerState = PlayerState.Free;
    }
    protected virtual void GetMovementInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    protected virtual UnityEngine.Vector3 HandleMovementInput()
    {
        UnityEngine.Vector3 moveInput = (cam.forward * verticalInput) + (cam.right * horizontalInput); // Tạo vector di chuyển theo hướng cam và input
        moveInput.y = 0f;
        return moveInput.normalized; // Chuẩn hóa vector thành độ lớn = 1 để nhất quán tốc độ di chuyển  
    }
}
