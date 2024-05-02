using TMPro;
using UnityEngine;
namespace Spin.Manager
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [SerializeField] private GameObject _failPanel;
        [SerializeField] private GameObject _leaveButton;
        [SerializeField] private TextMeshProUGUI _infoText;
        public void SetFailPanel(bool value)
        {
            _failPanel.SetActive(value);
        }
        public void SetLeaveButtonActivate(bool value)
        {
            _leaveButton.SetActive(value);
        }
        public void SetInfoText(bool value, string explanation)
        {
            _infoText.gameObject.SetActive(value);
            _infoText.text = explanation;
        }
    }
    public interface IUIManager
    {
        void SetFailPanel(bool value);
        void SetLeaveButtonActivate(bool value);
        void SetInfoText(bool value, string explanation);
    }
}
