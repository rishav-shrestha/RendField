using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public float jumpForce = 3.0f;
    public float wallJumpForce = 2.5f;
    public float sprintMultiplier = 4.0f;
    public float defaultGravityScale;
    public float wallslideMultiplier = 0.1f;
    public float fallMultiplier = 0.3f;
    private Player _player;
    
    
    private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;
    void Awake()
    {
        _player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb.gravityScale;
    }

    public void Move(float input, bool sprint)
    {
        float speed = sprint ? moveSpeed * sprintMultiplier : moveSpeed;
        Vector2 direction = new Vector2(input, 0).normalized;
        gameObject.transform.Translate(direction * Time.deltaTime * speed); 
    }

    public void FallMove(float input)
    {
        float speed =  moveSpeed * fallMultiplier;
        Vector2 direction = new Vector2(input, 0).normalized;
        gameObject.transform.Translate(direction * Time.deltaTime * speed); 
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    public void WallJump()
    {
        _player.input.Flip();
        rb.linearVelocity = new Vector2(_player.input.LookingRight?wallJumpForce:-wallJumpForce, jumpForce);
    }
}
