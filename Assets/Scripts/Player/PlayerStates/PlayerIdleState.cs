using UnityEngine;

public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(Player player) : base(player)
        {
        }

        public override void Enter()
        { 
            Debug.Log("Idle");
            _player.animationController.Idle();
        }

        public override void Update()
        {
            
            if (_player.input.HorizontalInput != 0)
            {
                if (!_player.sensor.isTouchingWall)
                {
                    if (_player.input.SprintPressed)
                    {
                        _player.stateMachine.ChangeState(new PlayerSprintState(_player));
                        return;
                    }
                    _player.stateMachine.ChangeState(new PlayerWalkState(_player));
                    return;
                }  
            }
            
            if (_player.input.JumpPressed)
            {
                _player.stateMachine.ChangeState(new PlayerJumpState(_player));
                return;
            }

            if (!_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerFallState(_player));
                return;
            }
        }
        


    }
