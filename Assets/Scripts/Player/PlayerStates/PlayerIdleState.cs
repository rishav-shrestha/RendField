using UnityEngine;

public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(Player player) : base(player)
        {
        }

        public override void Enter()
        { 
            _player.controller.Rb.linearVelocity = new Vector2(0, 0);
            _player.animationController.Idle();
        }

        public override void Update()
        {
            Debug.Log("Idle");
            if (_player.input.HorizontalInput != 0)
            {
                if (_player.input.SprintPressed)
                {
                    _player.stateMachine.ChangeState(new PlayerSprintState(_player));
                    return;
                }
                _player.stateMachine.ChangeState(new PlayerWalkState(_player));
            }

            if (_player.input.JumpPressed)
            {
                _player.stateMachine.ChangeState(new PlayerJumpState(_player));
            }
        }
        


    }
