using System;
using UnityEngine;

namespace Code.Multimeter
{
    public class MultimeterModel
    {
        public event Action<float, SectionType> ResultCalculated; 
        private float _resistance;
        private float _power;
        private float _aCVoltage;
        private float _currentPower;
        private float _dcVoltage;
        
        public void Init(MultimeterSettings multimeterSettings)
        {
            _resistance = multimeterSettings.Resistance;
            _power = multimeterSettings.Power;
            _aCVoltage = multimeterSettings.AcVoltage;
            Calculate();
        }

        private void Calculate()
        {
            CalculateCurrentPower();
            CalculateDcVoltage();
        }

        public float GetMultimeterResult(SectionType sectionType)
        {
            var result = 0f;

            switch (sectionType)
            {
                case SectionType.Resistance:
                    result = _resistance;
                    break;
                case SectionType.AcVoltage:
                    result = _aCVoltage;
                    break;
                case SectionType.CurrentPower:
                    result = _currentPower;
                    break;
                case SectionType.DcVoltage:
                    result = _dcVoltage;
                    break;
            }

            ResultCalculated?.Invoke(result, sectionType);
            return result;
        }
        
        private void CalculateCurrentPower()
        {
            _currentPower = Round(Mathf.Sqrt(_power / _resistance));
        }

        private void CalculateDcVoltage()
        {
            _dcVoltage  = Round(Mathf.Sqrt(_power * _resistance));
        }
        
        private float Round(float value)
        {
            return (float) Math.Round(value, 2);
        }
    }
}
