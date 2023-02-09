using Profile;
<<<<<<< Updated upstream:Assets/_Root/Scripts/Ui/MainMenuController.cs
using Tool;
=======
using Services;
>>>>>>> Stashed changes:Assets/_Root/Scripts/Ui/MainMenu/MainMenuController.cs
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private readonly EntryPoint _entryPoint;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, EntryPoint entryPoint)
        {
            _profilePlayer = profilePlayer;
            _entryPoint = entryPoint;
            _view = LoadView(placeForUi);
<<<<<<< Updated upstream:Assets/_Root/Scripts/Ui/MainMenuController.cs
            _view.Init(StartGame);
            _view.GoToSettings(GoToSettings);
            _view.ShowReward(ShowReward);
            _view.BuyDiamonds(BuyDiamonds);
=======
            _view.Init(StartGame, OpenSettings, OpenShed, PlayRewardedAds, BuyProduct);

            SubscribeAds();
            SubscribeIAP();
        }

        protected override void OnDispose()
        {
            UnsubscribeAds();
            UnsubscribeIAP();
>>>>>>> Stashed changes:Assets/_Root/Scripts/Ui/MainMenu/MainMenuController.cs
        }


        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() =>
            _profilePlayer.CurrentState.Value = GameState.Game;

        private void GoToSettings() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;

<<<<<<< Updated upstream:Assets/_Root/Scripts/Ui/MainMenuController.cs
        private void ShowReward() =>
            _entryPoint._adsService.RewardedPlayer.Play();

        private void BuyDiamonds() =>
            _entryPoint._iapService.Buy("1");
=======
        private void OpenShed() =>
            _profilePlayer.CurrentState.Value = GameState.Shed;

        private void PlayRewardedAds() =>
            ServiceRoster.AdsService.RewardedPlayer.Play();

        private void BuyProduct(string productId) =>
            ServiceRoster.IAPService.Buy(productId);

        private void SubscribeAds()
        {
            ServiceRoster.AdsService.RewardedPlayer.Finished += OnAdsFinished;
            ServiceRoster.AdsService.RewardedPlayer.Failed += OnAdsCancelled;
            ServiceRoster.AdsService.RewardedPlayer.Skipped += OnAdsCancelled;
        }

        private void UnsubscribeAds()
        {
            ServiceRoster.AdsService.RewardedPlayer.Finished -= OnAdsFinished;
            ServiceRoster.AdsService.RewardedPlayer.Failed -= OnAdsCancelled;
            ServiceRoster.AdsService.RewardedPlayer.Skipped -= OnAdsCancelled;
        }

        private void SubscribeIAP()
        {
            ServiceRoster.IAPService.PurchaseSucceed.AddListener(OnIAPSucceed);
            ServiceRoster.IAPService.PurchaseFailed.AddListener(OnIAPFailed);
        }

        private void UnsubscribeIAP()
        {
            ServiceRoster.IAPService.PurchaseSucceed.RemoveListener(OnIAPSucceed);
            ServiceRoster.IAPService.PurchaseFailed.RemoveListener(OnIAPFailed);
        }

        private void OnAdsFinished() => Log("You've received a reward for ads!");
        private void OnAdsCancelled() => Log("Receiving a reward for ads has been interrupted!");

        private void OnIAPSucceed() => Log("Purchase succeed");
        private void OnIAPFailed() => Log("Purchase failed");
>>>>>>> Stashed changes:Assets/_Root/Scripts/Ui/MainMenu/MainMenuController.cs
    }
}
