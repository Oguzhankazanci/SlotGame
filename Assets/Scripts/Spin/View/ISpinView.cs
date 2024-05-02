using UnityEngine;

namespace Spin.View
{
    public interface ISpinView
    {
        void SpinWheel();
        void HideUI(bool value);
        void UpdateWheel();
        Transform GetWheelTransform();

    }
}