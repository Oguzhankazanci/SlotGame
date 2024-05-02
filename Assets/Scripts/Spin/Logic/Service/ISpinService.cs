namespace Spin.Logic
{
    public interface ISpinService
    {
        void StartSpin();
        void Tick();

        void ResetSpinResult(bool win);
    }
}

