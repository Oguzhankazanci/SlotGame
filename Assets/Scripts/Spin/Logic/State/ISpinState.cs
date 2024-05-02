namespace Spin.Logic
{
    public interface ISpinState
    {
        void HandleState(SpinService service);
        bool GetWheelState();
    }
}
