using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAnimationController animationController;
    public PlayerController controller;
    public PlayerInput input;
    public PlayerSensor sensor;
    public PlayerStateMachine stateMachine;
    public string currentState;
    

    void Awake()
    {
        animationController = GetComponent<PlayerAnimationController>();
        controller = GetComponent<PlayerController>();
        input = GetComponent<PlayerInput>();
        sensor = GetComponent<PlayerSensor>();
        stateMachine = GetComponent<PlayerStateMachine>();
        stateMachine.Initialize(new PlayerIdleState(this));
    }
    void Update()
    {
        if (stateMachine.currentState != null)
        {
            stateMachine.Update(); 
            currentState = stateMachine.currentState.GetType().Name;
        }
    }
    void FixedUpdate()
    {
        if (stateMachine.currentState != null)
        {
            stateMachine.FixedUpdate();
        }
    }
}
