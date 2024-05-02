using Spin.Manager;

namespace Spin.UI
{
    public class ReviveButton : ButtonBase
    {

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
            _gameManager.CompleteSpin();
            _uiManager.SetFailPanel(false);
        }
    }
}
