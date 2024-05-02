namespace Spin.Logic
{
    public class RotationState : ISpinState
    {
        public void HandleState(SpinService service)
        {
            //Debug.Log("Çark dönüyor.");

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