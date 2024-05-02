using UnityEngine;
using UnityEngine.UI;

namespace Spin.UI
{
    public abstract class ButtonBase : MonoBehaviour
    {
        protected Button button;

        protected virtual void Start()
        {
            button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(TaskOnClick);
            }
            else
            {
                Debug.LogWarning("Button component not found on GameObject: " + gameObject.name);
            }
        }

        protected abstract void TaskOnClick();
    }
}