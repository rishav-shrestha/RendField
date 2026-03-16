using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public float jumpForce = 3.0f;
    public float sprintMultiplier = 4.0f;
    
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float input, bool sprint)
    {
        float speed = sprint ? moveSpeed * sprintMultiplier : moveSpeed;
        
        rb.linearVelocity = new Vector2(input * speed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
