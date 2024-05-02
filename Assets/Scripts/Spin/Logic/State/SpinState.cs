namespace Spin.Logic
{
    public class RotationState : ISpinState
    {
        public void HandleState(SpinService service)
        {
            //Debug.Log("�ark d�n�yor.");

        }
        public bool GetWheelState()
        {
            return true;
        }
    }

    public class StoppedState : ISpinState
    {
        public void HandleState(SpinService service)
        {
           service.SpinResult();

        }
        public bool GetWheelState()
        {
            return false;
        }
    }
}