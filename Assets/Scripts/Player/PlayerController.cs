using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public float jumpForce = 3.0f;
    public float sprintMultiplier = 4.0f;
    
    private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float input, bool sprint)
    {
        float speed = sprint ? moveSpeed * sprintMultiplier : moveSpeed;
        Vector2 direction = new Vector2(input, 0).normalized;
        gameObject.transform.Translate(direction * Time.deltaTime * speed); 
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
