using UnityEngine;

public class PlayerWallJumpState : PlayerState
    {
        public PlayerWallJumpState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            _player.animationController.Jump();
            _player.controller.WallJump();
            Debug.Log("WallJump");
        }

        public override void Update()
        {
            
            if (_player.controller.Rb.linearVelocity.y < 0)
            {
                _player.stateMachine.ChangeState(new PlayerFallState(_player));  
            }
           
        }
        


    }
