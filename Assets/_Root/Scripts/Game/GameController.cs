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
        [SerializeField] private AnalyticsManager _analytics;
        public GameController(ProfilePlayer profilePlayer, AnalyticsManager _analytics)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

            var carController = new CarController();
            AddController(carController);

            _analytics.SendGameStarted();
        }
    }
}
