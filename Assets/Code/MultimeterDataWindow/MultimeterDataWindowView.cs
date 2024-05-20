using Code.Multimeter;
using UnityEngine;

namespace Code.MultimeterDataWindow
{
    public class MultimeterDataWindowView : MonoBehaviour
    {
        [SerializeField] private SectionBlock[] _sectionBlocks;
        
        public void UpdateResult(float value, SectionType sectionType)
        {
            for (int i = 0, len = _sectionBlocks.Length; i < len; ++i)
            {
                var sectionBlock = _sectionBlocks[i];
                
                if (sectionType != sectionBlock.SectionType)
                {
                    sectionBlock.UpdateValueText(0);
                    continue;
                }
                
                sectionBlock.UpdateValueText(value);
            }
        }
    }
}
