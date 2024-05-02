namespace Spin.Logic
{
    public class SpinStateController:ISpinStateController
    {
        private ISpinState currentState;

        public void SetState(ISpinState state)
        {
            currentState = state;
        }

        public void HandleState(SpinService service)
        {
            currentState.HandleState(service);
        }
        public bool GetState()
        {
            return currentState.GetWheelState();
        }
    }
  
}