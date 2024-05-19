using UnityEngine;

namespace Code.Multimeter
{
    [CreateAssetMenu(menuName = nameof(MultimeterSettings), fileName = nameof(MultimeterSettings))]
    public class MultimeterSettings : ScriptableObject
    {
        [SerializeField] private float _resistance = 1000;
        [SerializeField] private float _power = 400;
        [SerializeField] private float _aCVoltage = 0.01f; 

        public float Resistance => _resistance;
        public float Power => _power;
        public float AcVoltage => _aCVoltage;
    }
}
