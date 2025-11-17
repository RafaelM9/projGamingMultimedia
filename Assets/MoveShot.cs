using UnityEngine;

public class MoveShot : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    
}
