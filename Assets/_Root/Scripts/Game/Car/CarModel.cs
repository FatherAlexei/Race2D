namespace Game.Car
{
    internal class CarModel
    {
<<<<<<< Updated upstream
        public readonly float Speed;

        public CarModel(float speed) =>
            Speed = speed;
=======
        private readonly float _defaultSpeed;

        public float Speed { get; set; }


        public CarModel(float speed)
        {
            _defaultSpeed = speed;
            Speed = speed;
        }


        public void Restore() =>
            Speed = _defaultSpeed;
>>>>>>> Stashed changes
    }
}
