using UnityEngine;

public class PlayerSprintState : PlayerState
    {
        public PlayerSprintState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
        _player.animationController.Sprint();
        }

        public override void Update()
        {
            Debug.Log("Sprint");
            if (_player.input.HorizontalInput == 0)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
            }

            if (!_player.input.SprintPressed)
            {
                _player.stateMachine.ChangeState(new PlayerWalkState(_player));
            }
            if (_player.input.JumpPressed)
            {
                _player.stateMachine.ChangeState(new PlayerSprintJumpState(_player));
            }
            if (!_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerFallState(_player));
            }
            _player.controller.Move(_player.input.HorizontalInput,true);
        }
        


    }
