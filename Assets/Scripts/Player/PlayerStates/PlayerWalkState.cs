using UnityEngine;

public class PlayerWalkState : PlayerState
    {
        public PlayerWalkState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
       _player.animationController.Walk();
        Debug.Log("Walk");
        }

        public override void Update()
        {
            
            if (_player.input.HorizontalInput == 0 || _player.sensor.isTouchingWall)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
            }
            if(_player.input.SprintPressed)
            {
                _player.stateMachine.ChangeState(new PlayerSprintState(_player));
            }
            if (_player.input.JumpPressed)
            {
                _player.stateMachine.ChangeState(new PlayerJumpState(_player));
            }
            if (!_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerFallState(_player));
            }
            _player.controller.Move(_player.input.HorizontalInput,false);
        }
        


    }
