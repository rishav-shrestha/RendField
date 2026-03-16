public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(Player player) : base(player)
        {
        }

        public override void Enter()
        {
            _player.animationController.Idle();
        }

        public override void Update()
        {
            if (_player.input.HorizontalInput != 0)
            {
                
            }

            if (_player.input.JumpPressed)
            {
                
            }

            if (_player.sensor.IsGrounded)
            {
                
            }
        }
        


    }
