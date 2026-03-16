using System;
using UnityEngine;
using UnityEngine.Serialization;

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

    public bool isGrounded;
    public bool isTouchingWallLeft;
    public bool isTouchingWallRight;

    
    void Update()
    {
        UpdateGrounded();
        UpdateWallChecks();
    }

    private void UpdateGrounded()
    {
        for(int i=0; i<groundCheck.Length; i++)
        {
            if(Physics2D.OverlapCircle(groundCheck[i].position, groundCheckRadius, groundLayer))
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }

    private void UpdateWallChecks()
    {
        for(int i=0; i<wallCheckLeft.Length; i++)
        {
            if(Physics2D.OverlapCircle(wallCheckLeft[i].position, wallCheckRadius, wallLayer))
            {
                isTouchingWallLeft = true;
                return;
            }
        }
        isTouchingWallLeft = false;
        for (int i = 0; i < wallCheckRight.Length; i++)
        {
            if (Physics2D.OverlapCircle(wallCheckRight[i].position, wallCheckRadius, wallLayer))
            {
                isTouchingWallRight = true;
                return;
            }
        }
        isTouchingWallRight = false;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (!showGizmos) return;

        Gizmos.color = Color.yellow;
        if (groundCheck != null)
        {
            foreach (var point in groundCheck)
            {
                if(!showGroundGizmos) continue;
                    Gizmos.DrawWireSphere(point.position, groundCheckRadius);  
            }
                
        }

        Gizmos.color = Color.red;
        if (wallCheckLeft != null)
        {
            foreach (var point in wallCheckLeft)
            {
                if(!showWallGizmos) continue;
                Gizmos.DrawWireSphere(point.position, wallCheckRadius);
            }
                
        }

        Gizmos.color = Color.blue;
        if (wallCheckRight != null)
        {
            foreach (var point in wallCheckRight)
            {
                if(!showWallGizmos) continue;
                Gizmos.DrawWireSphere(point.position, wallCheckRadius);
            }
                
        }
    }
}
