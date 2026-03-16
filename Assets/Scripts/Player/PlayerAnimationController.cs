using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator upperBody;
    public Animator lowerBody;


    public void Idle()
    {
        Set("walking", false);
        Set("running", false);
        Set("jump", false);
    }
    public void Walk()
    {
        Set("walking", true);
    }
    public void Run()
    {
        Set("running", true);
    }
    public void Jump()
    {
        Set("jump");
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
