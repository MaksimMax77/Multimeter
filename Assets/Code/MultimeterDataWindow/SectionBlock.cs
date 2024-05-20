using System.Globalization;
using Code.Multimeter;
using TMPro;
using UnityEngine;

namespace Code.MultimeterDataWindow
{
    public class SectionBlock : MonoBehaviour
    {
        [SerializeField] private SectionType _sectionType;
        [SerializeField] private TMP_Text _valueText;

        public SectionType SectionType => _sectionType;

        public void UpdateValueText(float value)
        {
            _valueText.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
