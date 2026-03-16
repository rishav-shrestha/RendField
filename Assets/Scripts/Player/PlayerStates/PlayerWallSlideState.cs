using UnityEngine;

public class PlayerWallSlideState : PlayerState
    {
        public PlayerWallSlideState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            _player.controller.Rb.linearVelocity = Vector3.zero; 
            _player.controller.Rb.gravityScale = _player.controller.defaultGravityScale*_player.controller.wallslideMultiplier;
            _player.animationController.WallSlide();
            Debug.Log("Fall");
        }

        public override void Update()
        {
            
            if (_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
            }
            if (!_player.sensor.isTouchingWall)
            {
                _player.stateMachine.ChangeState(new PlayerFallState(_player)); 
            }
            if (_player.input.JumpPressed)
            {
                _player.stateMachine.ChangeState(new PlayerWallJumpState(_player));
            }
        }
        
        public override void Exit()
        {
            _player.controller.Rb.gravityScale = _player.controller.defaultGravityScale;
        }


    }
