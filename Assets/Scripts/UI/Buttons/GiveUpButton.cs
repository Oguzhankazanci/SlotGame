using Spin.Controller;
using Spin.Manager;
using UnityEngine;

namespace Spin.UI
{
    public class GiveUpButton : ButtonBase
    {
        [SerializeField] private SpinController _spinController;

        private IGameManager _gameManager;
        private IUIManager _uiManager;

        [Zenject.Inject]
        private void Constructor([Zenject.Inject] IGameManager gameManager, [Zenject.Inject] IUIManager uiManager)
        {
            _gameManager = gameManager;
            _uiManager = uiManager;
        }

        protected override void TaskOnClick()
        {
            _gameManager.ResetSpinCount();
            _spinController.LoseSpinResult();
            _uiManager.SetFailPanel(false);
        }
    }
}