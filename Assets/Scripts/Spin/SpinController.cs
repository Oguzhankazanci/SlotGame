using Spin.Logic;
using Spin.Manager;
using Spin.Reward;
using Spin.View;
using UnityEngine;

namespace Spin.Controller
{
    public class SpinController : MonoBehaviour
    {
        private IGameManager _gameManager;
        private IDataManager _dataManager;
        private IUIManager _uiManager;

        private ISpinService _spinService;



        [Zenject.Inject]
        private void Constructor([Zenject.Inject] IGameManager gameManager, [Zenject.Inject] IDataManager dataManager, [Zenject.Inject] IUIManager uiManager)
        {
            _gameManager = gameManager;
            _dataManager = dataManager;
            _uiManager = uiManager; 
        }

        private void Start()
        {
            Initialize();
        }
        private void Initialize()
        {
            ISpinStrategy _spinStrategy = new DotweenSpinStrategy(_dataManager.GetSpinSettings());
            ISpinView _spinWheelView = GetComponent<SpinView>();
            IRewardView _rewardView = GetComponentInChildren<RewardView>();
            _spinService = new SpinService(_spinStrategy, _spinWheelView, _gameManager, _dataManager, _uiManager, _rewardView);
        }

        private void Update()
        {
            _spinService.Tick();
        }
        public void StartSpin()
        {
            _spinService.StartSpin();
        }
        public void WinSpinResult()
        {
            _spinService.ResetSpinResult(true);
        }
        public void LoseSpinResult()
        {
            _spinService.ResetSpinResult(false);
        }
    }
}
