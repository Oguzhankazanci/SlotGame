using UnityEngine;
using DG.Tweening;
using Spin.Data;

namespace Spin.Logic
{
    public class DotweenSpinStrategy : ISpinStrategy
    {
        private float _rotationDuration = 6f;
        private float _rotationInterval = 45f;

        float targetRotation;

        private Tweener _tweener;
        private bool _onSpinning;

        public DotweenSpinStrategy(SpinSettings settings)
        {
            _rotationDuration = settings.RotationDuration;
            _rotationInterval = 360f / settings.NumberOfImages;

        }

        public void StartSpin(Transform wheelTransform)
        {
            _onSpinning = true;
            _tweener = Spin(wheelTransform);
        }

        private Tweener Spin(Transform wheelTransform)
        {
            int randomInterval = Mathf.RoundToInt(Random.Range(0f, 7f));

            targetRotation = (randomInterval * _rotationInterval) + 1440f;

            Vector3 rotation = new Vector3(0f, 0f, targetRotation);
            return wheelTransform.DORotate(rotation, _rotationDuration, RotateMode.FastBeyond360).SetEase(Ease.OutQuad).OnComplete(() => OnSpinComplete());
        }
        public float GetElapsedSeconds()
        {
            if (_onSpinning)
            {
                return _tweener.Elapsed();
            }
            else
            {
                return -1;
            }

        }
        public float GetResultAngle()
        {
            return targetRotation;
        }

        public void OnSpinComplete()
        {
            _tweener.Kill();
            _onSpinning = false;
        }
        public void ResetSpin(Transform wheelTransform)
        {
            wheelTransform.eulerAngles = Vector3.zero;  
        }
        public bool GetWheelState()
        {
            return _onSpinning;
        }

    }
}