using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput;
    public bool JumpPressed;
    public bool SprintPressed;
    public bool LookingRight;
    private Player player;

    public void Awake()
    {
        LookingRight= transform.localScale.x > 0;
        player = GetComponent<Player>();
    }
    void Update()
    {
     HorizontalInput = Input.GetAxisRaw("Horizontal");
     JumpPressed = Input.GetKeyDown(KeyCode.W);
     SprintPressed = Input.GetKey(KeyCode.LeftShift);
     HandleLookDirection();
    }
    void HandleLookDirection()
    {
        if (HorizontalInput > 0 && !LookingRight)
            Flip();
        else if (HorizontalInput < 0 && LookingRight)
            Flip();
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        LookingRight = !LookingRight;
    }
    public void  ResetJump()
    {
        JumpPressed = false;
    }
}
