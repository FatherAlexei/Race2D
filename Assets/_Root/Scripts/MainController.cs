using Ui;
using Game;
using Profile;
using UnityEngine;
<<<<<<< Updated upstream
using Services.Analytics;
=======
using Features.Shed;
using Features.Inventory;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
        _mainMenuController?.Dispose();
        _gameController?.Dispose();

=======
        DisposeControllers();
>>>>>>> Stashed changes
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        DisposeControllers();

        switch (state)
        {
            case GameState.Start:
<<<<<<< Updated upstream
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
=======
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Shed:
                _shedController = new ShedContext(_placeForUi, _profilePlayer);
                break;
            case GameState.Game:
                _gameController = new GameController(_placeForUi, _profilePlayer);
>>>>>>> Stashed changes
                break;
        }
    }

    private void DisposeControllers()
    {
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
        _gameController?.Dispose();
    }
}
