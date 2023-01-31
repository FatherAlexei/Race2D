using Ui;
using Game;
using Profile;
using UnityEngine;
using Services.Analytics;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly AnalyticsManager _analyticsManager;
    private readonly EntryPoint _entryPoint;

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsMenuController _settingsController;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, AnalyticsManager analyticsManager, EntryPoint entryPoint)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _analyticsManager = analyticsManager;
        _entryPoint = entryPoint;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer, _entryPoint);
                _gameController?.Dispose();
                _settingsController?.Dispose();
                break;
            case GameState.Settings:
                _settingsController = new SettingsMenuController(_placeForUi, _profilePlayer);
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer, _analyticsManager);
                _mainMenuController?.Dispose();
                _settingsController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _settingsController?.Dispose();
                break;
        }
    }
}
