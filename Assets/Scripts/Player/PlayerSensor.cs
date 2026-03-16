using System;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    [Header("Ground Sensor")]
    public Transform[] groundCheck;
    public float groundCheckRadius=0.1f;
    public LayerMask groundLayer;
    
    [Header("Wall Sensor")]
    public LayerMask wallLayer;
    public float wallCheckRadius=0.1f;
    public Transform[] wallCheckLeft;
    public Transform[] wallCheckRight;
    
    [Header("Debug Options")]
    public bool showGizmos;
    public bool showWallGizmos;
    public bool showGroundGizmos;
    
    public bool IsGrounded { get; private set; }
    public bool IsTouchingWallLeft { get; private set; }
    public bool IsTouchingWallRight { get; private set; }

    
    void Update()
    {
    }

    private void UpdateGrounded()
    {
        for(int i=0; i<groundCheck.Length; i++)
        {
            if(Physics2D.OverlapCircle(groundCheck[i].position, groundCheckRadius, groundLayer))
            {
                IsGrounded = true;
                return;
            }
        }
        IsGrounded = false;
    }

    private void UpdateWallChecks()
    {
        for(int i=0; i<wallCheckLeft.Length; i++)
        {
            if(Physics2D.OverlapCircle(wallCheckLeft[i].position, wallCheckRadius, wallLayer))
            {
                IsTouchingWallLeft = true;
                return;
            }
        }
        IsTouchingWallLeft = false;
        for (int i = 0; i < wallCheckRight.Length; i++)
        {
            if (Physics2D.OverlapCircle(wallCheckRight[i].position, wallCheckRadius, wallLayer))
            {
                IsTouchingWallRight = true;
                return;
            }
        }
        IsTouchingWallRight = false;
    }
}
