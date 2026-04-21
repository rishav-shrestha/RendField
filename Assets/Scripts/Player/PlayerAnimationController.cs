using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator upperBody;
    public Animator lowerBody;


    public void Idle()
    {
        Set("state", (int)AnimState.Idle);
    }
    public void Walk()
    {
        Set("state", (int)AnimState.Walk);
    }
    public void Sprint()
    {
        Set("state", (int)AnimState.Sprint);
    }
    public void Jump()
    {
        Set("state", (int)AnimState.Jump);
    }

    public void Fall()
    {
        Set("state", (int)AnimState.Fall);
    }

    public void SprintJump()
    {
        Set("state", (int)AnimState.SprintJump);
    }
    public void WallSlide()
    {
        Set("state", (int)AnimState.WallSlide);
    }
    public void Set(string param)
    {
        upperBody.SetTrigger(param);
        lowerBody.SetTrigger(param);
        Debug.Log("Playing: " + param + "animation.");
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

public enum AnimState
{
    Idle,
    Walk,
    Sprint,
    Jump,
    Fall,
    WallSlide,
    SprintJump,
}
