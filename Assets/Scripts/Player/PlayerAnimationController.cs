using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator upperBody;
    public Animator lowerBody;


    public void Idle()
    {
        Set("idle");
    }
    public void Walk()
    {
        Set("walk");
    }
    public void Sprint()
    {
        Set("sprint");
    }
    public void Jump()
    {
        Set("jump");
    }

    public void Fall()
    {
        Set("fall");
    }

    public void SprintJump()
    {
        Set("sprint_jump");
    }
    public void Set(string param)
    {
        upperBody.SetTrigger(param);
        lowerBody.SetTrigger(param);
    }
    public void Set(string param, float value)
    {
        upperBody.SetFloat(param, value);
        lowerBody.SetFloat(param, value);
    }
    public void Set(string param, int value)
    {
        upperBody.SetInteger(param, value);
        lowerBody.SetInteger(param, value);
    }
    public void Set(string param, bool value)
    {
        upperBody.SetBool(param, value);
        lowerBody.SetBool(param, value);
    }
}
