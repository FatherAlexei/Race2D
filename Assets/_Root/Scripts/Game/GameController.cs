<<<<<<< Updated upstream
=======
using Tool;
using Profile;
using Services;
using UnityEngine;
>>>>>>> Stashed changes
using Game.Car;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Services.Analytics;
using Services.Analytics.UnityAnalytics;
using Tool;
using UnityEngine;
using UnityEngine.Analytics;

namespace Game
{
    internal class GameController : BaseController
    {
<<<<<<< Updated upstream
        [SerializeField] private AnalyticsManager _analytics;
        public GameController(ProfilePlayer profilePlayer, AnalyticsManager _analytics)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
=======
        private readonly SubscriptionProperty<float> _leftMoveDiff;
        private readonly SubscriptionProperty<float> _rightMoveDiff;

        private readonly CarController _carController;
        private readonly InputGameController _inputGameController;
        private readonly TapeBackgroundController _tapeBackgroundController;
        private readonly AbilitiesContext _abilitiesContext;


        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _leftMoveDiff = new SubscriptionProperty<float>();
            _rightMoveDiff = new SubscriptionProperty<float>();

            _carController = CreateCarController();
            _inputGameController = CreateInputGameController(profilePlayer, _leftMoveDiff, _rightMoveDiff);
            _tapeBackgroundController = CreateTapeBackground(_leftMoveDiff, _rightMoveDiff);
            _abilitiesContext = CreateAbilitiesContext(placeForUi, _carController);

            ServiceRoster.Analytics.SendGameStarted();
        }

>>>>>>> Stashed changes

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

            var carController = new CarController();
            AddController(carController);

<<<<<<< Updated upstream
            _analytics.SendGameStarted();
=======
            return carController;
        }

        private AbilitiesContext CreateAbilitiesContext(Transform placeForUi, IAbilityActivator abilityActivator)
        {
            var context = new AbilitiesContext(placeForUi, abilityActivator);
            AddContext(context);

            return context;
>>>>>>> Stashed changes
        }
    }
}
