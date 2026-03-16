using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAnimationController animationController;
    public PlayerController controller;
    public PlayerInput input;
    public PlayerSensor sensor;
    public PlayerStateMachine stateMachine;
    
    

    void Awake()
    {
        animationController = GetComponent<PlayerAnimationController>();
        controller = GetComponent<PlayerController>();
        input = GetComponent<PlayerInput>();
        sensor = GetComponent<PlayerSensor>();
        stateMachine = GetComponent<PlayerStateMachine>();
    }
    void Update()
    {
        if (stateMachine.currentState != null)
        {
            stateMachine.Update(); 
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
