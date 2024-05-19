using System;
using UnityEngine;

namespace Code.Multimeter
{
    public class SmoothRotator : MonoBehaviour
    {
        [SerializeField] private Transform _rotatingTransform;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _rotateLerpPercentMaxValue;
        private Action _onRotationComplete;
        private Vector3 _targetEulerAngles;
        private float _rotationValue;
        private float _rotateLerpPercent;
        private bool _isRotating;

        public void StartRotate(Vector3 targetEulerAngles, Action onRotationComplete)
        {
            _targetEulerAngles = targetEulerAngles;
            _onRotationComplete = onRotationComplete;
            _isRotating = true;
        }

        private void Update()
        {
            if (!_isRotating)
            {
                return;
            }

            if (CheckRotationComplete())
            {
                OnRotationCompleteInvoke();
                Reset();
                return;
            }

            SetRotateLerpPercent();
            Rotate();
        }

        private bool CheckRotationComplete()
        {
            return _rotateLerpPercent >= _rotateLerpPercentMaxValue;
        }

        private void OnRotationCompleteInvoke()
        {
            _onRotationComplete?.Invoke();
        }

        private void Reset()
        {
            _rotateLerpPercent = 0;
            _isRotating = false;
        }

        private void SetRotateLerpPercent()
        {
            _rotateLerpPercent = Mathf.MoveTowards(_rotateLerpPercent, 1f, 
                Time.deltaTime * _rotateSpeed);
        }

        private void Rotate()
        {
            _rotatingTransform.localRotation = Quaternion.Lerp(_rotatingTransform.localRotation,
                Quaternion.Euler(_targetEulerAngles), _rotateLerpPercent);
        }

        private void OnDestroy()
        {
            _onRotationComplete = null;
        }
    }
}
