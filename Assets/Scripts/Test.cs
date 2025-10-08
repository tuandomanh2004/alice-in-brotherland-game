using UnityEngine;

public class ApplyForceExample : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 forceDirection = new Vector3(0, 10, 0); // Upward force
    public float forceMagnitude = 5f;

    void Start()
    {
        // Apply force in the specified direction
        rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
    }
}
