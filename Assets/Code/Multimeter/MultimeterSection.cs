using System;
using UnityEngine;

namespace Code.Multimeter
{
    [Serializable]
    public struct MultimeterSection
    {
        public Vector3 targetEulerAngles;
        public SectionType sectionType;
    }
}
