using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace Code.Multimeter
{
    public class MultimeterView : MonoBehaviour
    {
        public Action<SectionType> SectionSwitched;
        [SerializeField] private SectionsSwitcher _sectionsSwitcher;
        [SerializeField] private SmoothRotator smoothRotator;
        [SerializeField] private TMP_Text _resultText;

        public void OnScrollUp()
        {
            _sectionsSwitcher.Switch(true);
            StartSwitchRotating();
        }

        public void OnScrollDown()
        {
            _sectionsSwitcher.Switch(false);
            StartSwitchRotating();
        }

        private void StartSwitchRotating()
        {
            smoothRotator.StartRotate(_sectionsSwitcher.GetCurrentSection().targetEulerAngles, 
                OnRotationComplete);
        }

        private void OnRotationComplete()
        {
            SectionSwitched?.Invoke(_sectionsSwitcher.GetCurrentSection().sectionType);
            _sectionsSwitcher.IsSwitchingSetFalse();
        }

        public void ResultTextUpdate(float value)
        {
            _resultText.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}