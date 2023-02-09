using Profile;
using Tool;
using UnityEngine;
using Services.IAP;
using Services.Analytics;
using Services.Ads.UnityAds;

internal class EntryPoint : MonoBehaviour
{
<<<<<<< Updated upstream
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;
=======
    private float _speedCar;
    private GameState _initialState;
>>>>>>> Stashed changes

    [Header("Scene Objects")]
    [SerializeField] private Transform _placeForUi;
    [SerializeField] public IAPService _iapService;
    [SerializeField] public UnityAdsService _adsService;
    [SerializeField] private AnalyticsManager _analytics;

    private MainController _mainController;
    private EntryPointConfig _entryPointConfig;


    private readonly ResourcePath _cfgPath = new ResourcePath("Configs/EntryPoint/EntryPointConfig");


    private void Start()
    {
<<<<<<< Updated upstream
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState);
        _mainController = new MainController(_placeForUi, profilePlayer, _analytics, this);

        _analytics.SendMainMenuOpened();

        if (_adsService.IsInitialized) OnAdsInitialized();
        else _adsService.Initialized.AddListener(OnAdsInitialized);

        if (_iapService.IsInitialized) OnIapInitialized();
        else _iapService.Initialized.AddListener(OnIapInitialized);
=======
        _entryPointConfig = ResourcesLoader.LoadObject<EntryPointConfig>(_cfgPath);
        _speedCar = _entryPointConfig.speedCar;
        _initialState = _entryPointConfig.initialState;
            

        var profilePlayer = new ProfilePlayer(_speedCar, _initialState);
        _mainController = new MainController(_placeForUi, profilePlayer);
>>>>>>> Stashed changes
    }

    private void OnDestroy()
    {
        _adsService.Initialized.RemoveListener(OnAdsInitialized);
        _iapService.Initialized.RemoveListener(OnIapInitialized);
        _mainController.Dispose();
    }


    private void OnAdsInitialized() => _adsService.InterstitialPlayer.Play();
    private void OnIapInitialized() => _iapService.Buy("Diamonds");
}
