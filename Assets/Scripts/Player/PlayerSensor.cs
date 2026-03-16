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
    public Transform[] wallCheck;
    
    [Header("Debug Options")]
    public bool showGizmos;
    public bool showWallGizmos;
    public bool showGroundGizmos;

    public bool isGrounded;
    public bool isTouchingWall;

    
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
     
        for (int i = 0; i < wallCheck.Length; i++)
        {
            if (Physics2D.OverlapCircle(wallCheck[i].position, wallCheckRadius, wallLayer))
            {
                isTouchingWall = true;
                return;
            }
        }
        isTouchingWall = false;
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
        Gizmos.color = Color.blue;
        if (wallCheck != null)
        {
            foreach (var point in wallCheck)
            {
                if(!showWallGizmos) continue;
                Gizmos.DrawWireSphere(point.position, wallCheckRadius);
            }
                
    }
}
}
