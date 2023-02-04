using Tool;
using Game.Car;
using Features.Inventory;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;
        public readonly InventoryModel Inventory;


        public ProfilePlayer(float speedCar, float jumpPower , GameState initialState) : this(speedCar, jumpPower)
        {
            CurrentState.Value = initialState;
        }

        public ProfilePlayer(float speedCar, float jumpPower)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new CarModel(speedCar, jumpPower);
            Inventory = new InventoryModel();
        }
    }
}
