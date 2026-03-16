using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput;
    public bool JumpPressed;
    public bool SprintPressed;
    
    // Update is called once per frame
    void Update()
    {
     HorizontalInput = Input.GetAxisRaw("Horizontal");
     JumpPressed = Input.GetKeyDown(KeyCode.W);
     SprintPressed = Input.GetKey(KeyCode.LeftShift);
    }
    public void  ResetJump()
    {
        JumpPressed = false;
    }
}
