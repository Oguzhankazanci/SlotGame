using UnityEngine;

namespace Spin.Logic
{
    public interface ISpinStrategy
    {
        void StartSpin(Transform wheelTransform);
        float GetElapsedSeconds();
        float GetResultAngle();
        void ResetSpin(Transform wheelTransform);
        bool GetWheelState();

    }
}

