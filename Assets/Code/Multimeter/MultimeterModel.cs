using System;
using UnityEngine;

namespace Code.Multimeter
{
    public class MultimeterModel 
    {
        public float Resistance { get; private set; }
        public float Power { get; private set; }
        public float ACVoltage { get; private set; }
        public float CurrentPower { get; private set; }
        public float DcVoltage { get; private set; }
        
        public void Init(MultimeterSettings multimeterSettings)
        {
            Resistance = multimeterSettings.Resistance;
            Power = multimeterSettings.Power;
            ACVoltage = multimeterSettings.AcVoltage;
            Calculate();
        }

        private void Calculate()
        {
            CalculateCurrentPower();
            CalculateDcVoltage();
        }
        
        private void CalculateCurrentPower()
        {
            CurrentPower = Round(Mathf.Sqrt(Power / Resistance));
        }

        private void CalculateDcVoltage()
        {
            DcVoltage  = Round(Mathf.Sqrt(Power * Resistance));
        }
        
        private float Round(float value)
        {
            return (float) Math.Round(value, 2);
        }
    }
}
