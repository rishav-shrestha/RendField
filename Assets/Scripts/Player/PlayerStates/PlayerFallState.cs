using UnityEngine;

public class PlayerFallState : PlayerState
    {
        public PlayerFallState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
          _player.animationController.Fall();
          Debug.Log("Fall");
        }

        public override void Update()
        {
            
            if (_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
            }

            if (_player.sensor.isTouchingWall)
            {
                _player.stateMachine.ChangeState(new PlayerWallSlideState(_player));
            }
            if (!_player.sensor.isTouchingWall)
            {
                _player.controller.FallMove(_player.input.HorizontalInput);  
            }
        }
        


    }
