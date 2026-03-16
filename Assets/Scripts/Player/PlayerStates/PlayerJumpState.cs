using UnityEngine;

public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            _player.animationController.Jump();
            if (_player.sensor.isGrounded)
            {
                _player.controller.Jump(); 
            }
            Debug.Log("Jump");
        }

        public override void Update()
        {
            if (_player.controller.Rb.linearVelocity.y < 0)
            {
                _player.stateMachine.ChangeState(new PlayerFallState(_player));
            }
            if(_player.input.SprintPressed && _player.input.HorizontalInput != 0 
                                           && !_player.sensor.isTouchingWall)
            {
                _player.stateMachine.ChangeState(new PlayerSprintJumpState(_player));
            }

            if (!_player.sensor.isTouchingWall)
            {
                _player.controller.Move(_player.input.HorizontalInput,false);  
            }
            
        }
        


    }
