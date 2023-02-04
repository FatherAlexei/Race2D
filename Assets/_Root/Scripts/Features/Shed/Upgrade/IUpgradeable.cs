namespace Features.Shed.Upgrade
{
    internal interface IUpgradable
    {
        float Speed { get; set; }
        float JumpBoost { get; set; }
        void Restore();
    }
}
