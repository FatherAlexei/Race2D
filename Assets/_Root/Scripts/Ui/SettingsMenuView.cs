using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class SettingsMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonBack;


        public void Init(UnityAction Back) =>
            _buttonBack.onClick.AddListener(Back);

        public void OnDestroy() =>
            _buttonBack.onClick.RemoveAllListeners();
    }
}