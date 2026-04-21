using UnityEngine;

public class PlayerSprintState : PlayerState
    {
        public PlayerSprintState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
        _player.animationController.Sprint();
        Debug.Log("Sprint");
        }

        public override void Update()
        {
            if (_player.input.HorizontalInput == 0 || _player.sensor.isTouchingWall)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
                return;
            }

            if (!_player.input.SprintPressed)
            {
                _player.stateMachine.ChangeState(new PlayerWalkState(_player));
                return;
            }
            if (_player.input.JumpPressed)
            {
                _player.stateMachine.ChangeState(new PlayerSprintJumpState(_player));
                return;
            }
            if (!_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerFallState(_player));
                return;
            }
            _player.controller.Move(_player.input.HorizontalInput,true);
        }
        


    }
