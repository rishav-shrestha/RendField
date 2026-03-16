using UnityEngine;

public class PlayerSprintJumpState : PlayerState
    {
        public PlayerSprintJumpState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            if (_player.sensor.isGrounded)
            {
                _player.controller.Jump(); 
            }
            _player.animationController.SprintJump();
        }

        public override void Update()
        {
            Debug.Log("SprintJump");
            if (_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
            }
            if (!_player.input.SprintPressed||_player.input.HorizontalInput == 0)
            {
                _player.stateMachine.ChangeState(new PlayerJumpState(_player));
            }
            _player.controller.Move(_player.input.HorizontalInput,true);
        }
        


    }
