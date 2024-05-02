namespace Spin.Logic
{
    public interface ISpinStateController
    {
        void SetState(ISpinState state);
        void HandleState(SpinService service);
        bool GetState();

    }
}