using Spin.Controller;
using Spin.Manager;
using UnityEngine;

namespace Spin.UI
{
    public class LeaveButton : ButtonBase
    {
        [SerializeField] private SpinController _spinController;

        private IGameManager _gameManager;

        [Zenject.Inject]
        private void Constructor([Zenject.Inject] IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        protected override void TaskOnClick()
        {
            _gameManager.ResetSpinCount();
            _spinController.WinSpinResult();
        }
    }
}
