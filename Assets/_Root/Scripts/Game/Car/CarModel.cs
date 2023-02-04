using Features.Shed.Upgrade;

namespace Game.Car
{
    internal class CarModel : IUpgradable
    {
        private readonly float _defaultSpeed;

        private readonly float _defaultJumpBoost;

        public float Speed { get; set; }
        public float JumpBoost { get; set; }

        public CarModel(float speed, float jump)
        {
            _defaultSpeed = speed;
            Speed = speed;
            _defaultJumpBoost = jump;
            JumpBoost = jump;
        }


        public void Restore()
        {
            Speed = _defaultSpeed;
            JumpBoost = _defaultJumpBoost;
        }
    }
}
