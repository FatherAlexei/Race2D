using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonReward;
        [SerializeField] private Button _buttonBuy;

        public void Init(UnityAction startGame) =>
            _buttonStart.onClick.AddListener(startGame);

        public void GoToSettings(UnityAction goToSettings) =>
            _buttonSettings.onClick.AddListener(goToSettings);

        public void ShowReward(UnityAction showReward) =>
            _buttonReward.onClick.AddListener(showReward);

        public void BuyDiamonds(UnityAction buyDiamonds) =>
            _buttonBuy.onClick.AddListener(buyDiamonds);

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonSettings.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
            _buttonBuy.onClick.RemoveAllListeners();
        }
    }
}
