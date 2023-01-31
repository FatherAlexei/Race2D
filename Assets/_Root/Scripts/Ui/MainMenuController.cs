using Profile;
using Tool;
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
            _view.Init(StartGame);
            _view.GoToSettings(GoToSettings);
            _view.ShowReward(ShowReward);
            _view.BuyDiamonds(BuyDiamonds);
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

        private void ShowReward() =>
            _entryPoint._adsService.RewardedPlayer.Play();

        private void BuyDiamonds() =>
            _entryPoint._iapService.Buy("1");
    }
}
