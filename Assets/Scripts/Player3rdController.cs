using UnityEngine;

public class Player3rdController : PlayerController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Update()
    {
        base.Update();
    }
    protected override void Move()
    {
        GetMovementInput();
        moveDir = HandleMovementInput();
        if (moveDir != Vector3.zero) // Nếu player chuyển động thì xoay theo vector di chuyển
        {
            MakeRotation();
            controller.Move(moveDir * playerSpeed * Time.deltaTime); // di chuyển theo vector
        }
    }
    public void MakeRotation()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(moveDir,Vector3.up); // tạo góc quay
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);  // tạo chuyển động quay
    }
}
