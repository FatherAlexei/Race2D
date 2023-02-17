using UnityEngine;

namespace Rewards
{
    internal class InstallView : MonoBehaviour
    {
        [SerializeField] private RewardView _dailyRewardView;

        private RewardController _rewardController;


        private void Awake() =>
            _rewardController = new RewardController(_dailyRewardView);

        private void Start() =>
            _rewardController.Init();

        private void OnDestroy() =>
            _rewardController.Deinit();
    }
}
