using UnityEngine;

namespace Code.Multimeter
{
    public class SectionsSwitcher : MonoBehaviour
    {
        [SerializeField] private MultimeterSection[] _sections;
        private int _currentSectionIndex;
        private bool _isSwitching;

        private void Awake()
        {
            enabled = false;
        }

        public MultimeterSection GetCurrentSection()
        {
            return _sections[_currentSectionIndex];
        }

        public void IsSwitchingSetFalse()
        {
            _isSwitching = false;
        }

        public void Switch(bool isNext)
        {
            if (!CanSwitch())
            {
                return;
            }

            _isSwitching = true;

            if (isNext)
            {
                MoveNext();
            }
            else
            {
                MoveBack();
            }
        }

        private bool CanSwitch()
        {
            return enabled && !_isSwitching;
        }

        private void MoveNext()
        {
            ++_currentSectionIndex;

            if (_currentSectionIndex >= _sections.Length)
            {
                _currentSectionIndex = 0;
            }
        }

        private void MoveBack()
        {
            --_currentSectionIndex;

            if (_currentSectionIndex < 0)
            {
                _currentSectionIndex = _sections.Length - 1;
            }
        }
    }
}
