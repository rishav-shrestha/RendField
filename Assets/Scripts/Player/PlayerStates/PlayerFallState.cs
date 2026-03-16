using UnityEngine;

public class PlayerFallState : PlayerState
    {
        public PlayerFallState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
          _player.animationController.Fall();
        }

        public override void Update()
        {
            Debug.Log("Fall");
            if (_player.sensor.isGrounded)
            {
                _player.stateMachine.ChangeState(new PlayerIdleState(_player));
            }
            _player.controller.Move(_player.input.HorizontalInput,false);
        }
        


    }
