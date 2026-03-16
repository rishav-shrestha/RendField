using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState;
    
    public void Update() => currentState.Update();
    public void FixedUpdate() => currentState.FixedUpdate();
    
    public void Initialize(PlayerState state)
    {
        currentState = state;
        state.Enter();
    }

    public void ChangeState(PlayerState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
