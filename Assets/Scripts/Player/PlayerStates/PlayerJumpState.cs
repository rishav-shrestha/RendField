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
        }

        public override void Update()
        {
            Debug.Log("Jump");
            if (_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
            }
            if(_player.input.SprintPressed && _player.input.HorizontalInput != 0 
                                           && !_player.sensor.isTouchingWallLeft
                                           && !_player.sensor.isTouchingWallRight)
            {
                _player.stateMachine.ChangeState(new PlayerSprintJumpState(_player));
            }
            _player.controller.Move(_player.input.HorizontalInput,false);
        }
        


    }
