using Spin.Manager;
using Spin.Reward;
using Spin.View;

namespace Spin.Logic
{
    public class SpinService : ISpinService
    {
        private readonly ISpinStrategy _spinStrategy;
        private readonly ISpinView _spinView;
        private readonly ISpinStateController _spinStateController;
        private readonly ISpinState _spinStartRotationState;
        private readonly ISpinState _spinStopRotationState;

        private readonly IRewardSystemService _rewardSystemService;


        private IGameManager _gameManager;
        private IDataManager _dataManager;
        private IUIManager _uiManager;



        public SpinService(ISpinStrategy spinStrategy, ISpinView spinView, IGameManager gameManager, IDataManager dataManager, IUIManager uiManager, IRewardView rewardView)
        {
            this._spinStrategy = spinStrategy;
            this._spinView = spinView;

            _gameManager = gameManager;
            _dataManager = dataManager;
            _uiManager = uiManager;

            _spinStateController = new SpinStateController();

            _spinStartRotationState = new RotationState();
            _spinStopRotationState = new StoppedState();
            _spinStateController.SetState(_spinStopRotationState);

            IRewardCalculationStrategy spinRewardCal = new RewardCalculationStrategy();
            _rewardSystemService = new RewardSystemService(spinRewardCal, rewardView, dataManager, _gameManager);
        }

        public void StartSpin()
        {
            if (_spinStateController.GetState()) { return; }
            _spinView.SpinWheel();
            _spinStrategy.StartSpin(_spinView.GetWheelTransform());
            _spinStateController.SetState(_spinStartRotationState);
            _spinStateController.HandleState(this);
            _uiManager.SetLeaveButtonActivate(false);
        }
        public void Tick()
        {
            // Test Input
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    StartSpin();
            //}

            if (_spinStateController.GetState())
            {
                if (_spinStrategy.GetElapsedSeconds() >= 1.5f && _spinStrategy.GetElapsedSeconds() < 3.5f)
                {
                    _spinView.HideUI(true);
                }
                else if (_spinStrategy.GetElapsedSeconds() >= 3.5f)
                {
                    _spinView.HideUI(false);
                }

                if (!_spinStrategy.GetWheelState())
                {
                    _spinStateController.SetState(_spinStopRotationState);
                    _spinStateController.HandleState(this);
                }

            }
        }

        public void SpinResult()
        {
            _rewardSystemService.CalculateReward(_spinStrategy.GetResultAngle(), _dataManager.GetSpinSettings().NumberOfImages);

            if (_rewardSystemService.GetResult())
                _gameManager.CompleteSpin();
            else
                _uiManager.SetFailPanel(true);

            _spinView.UpdateWheel();
            _uiManager.SetLeaveButtonActivate(true);

        }
        public void ResetSpinResult(bool win)
        {
            _rewardSystemService.ResetResult(win);
            _spinStrategy.ResetSpin(_spinView.GetWheelTransform());
        }
    }
}