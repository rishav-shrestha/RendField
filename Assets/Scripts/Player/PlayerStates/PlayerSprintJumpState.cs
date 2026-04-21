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
            Debug.Log("SprintJump");
        }

        public override void Update()
        {
           
            if (_player.sensor.isGrounded && _player.controller.Rb.linearVelocity.y < 0)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
                return;
            }
            if (!_player.input.SprintPressed||_player.input.HorizontalInput == 0||_player.sensor.isTouchingWall)
            {
                _player.stateMachine.ChangeState(new PlayerJumpState(_player));
                return;
            }
            _player.controller.Move(_player.input.HorizontalInput,true);
        }
        


    }
