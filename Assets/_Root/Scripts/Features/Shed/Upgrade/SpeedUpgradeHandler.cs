namespace Features.Shed.Upgrade
{
    internal class SpeedUpgradeHandler : IUpgradeHandler
    {
        private readonly float _speed;
        private readonly float _jumpBoost;

        public SpeedUpgradeHandler(float speed, float jumpBoost) {
            _jumpBoost = jumpBoost;
            _speed = speed;
        }

        public void Upgrade(IUpgradable upgradable)
        {
            upgradable.Speed += _speed;
            upgradable.JumpBoost += _jumpBoost;
        }
    }
}
