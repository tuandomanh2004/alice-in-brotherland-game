using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [Header("Look")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float verticalRotation;
    [SerializeField] private float horizontalRotation;
    [SerializeField] private float minAngle, maxAngle;

    [Header("Reference")]
    [SerializeField] private Transform player;

    [Header("HeadBobbing")]
    [SerializeField] private float timer = 0f;
    [SerializeField] private float basePoint;
    [SerializeField] private float resetSpeed;
    [SerializeField] private float bobbingSpeed;
    [SerializeField] private float bobbingAmount;

    void Start()
    {
        basePoint = transform.localPosition.y;
    }
    void Update()
    {
        HandleRotate();
        HandleHeadBobbing();
    }
    void HandleRotate()
    {
        // Input
        float mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseYInput = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Handle input
        verticalRotation -= mouseYInput;
        verticalRotation = Mathf.Clamp(verticalRotation, minAngle, maxAngle);

        // Rotate
        transform.localRotation = UnityEngine.Quaternion.Euler(verticalRotation, 0f, 0f);
        player.Rotate(mouseXInput * UnityEngine.Vector3.up);
    }
    void HandleHeadBobbing()
    {
        // Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        UnityEngine.Vector3 localPos = transform.localPosition;

        // Reset motion if movement = 0
        if (horizontal == 0 && vertical == 0)
        {
            timer = 0;
            localPos.y = Mathf.Lerp(localPos.y, basePoint, resetSpeed * Time.deltaTime);
            transform.localPosition = localPos;
        }

        // Head bob
        else
        {
            float sineWave = Mathf.Sin(timer);
            timer += bobbingSpeed * Time.deltaTime;
            localPos.y = basePoint + sineWave * bobbingAmount;
            transform.localPosition = localPos;
        }
    }
}
