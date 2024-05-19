using System;
using Code.System.Updating;
using UnityEngine;

namespace Code.InputControlling
{
    public class ScrollHandler: IUpdatableObject
    {
        public event Action ScrollUp;
        public event Action ScrollDown;
        
        public void Update()
        {
            switch (Input.mouseScrollDelta.y)
            {
                case > 0:
                    ScrollUp?.Invoke();
                    break;
                case < 0:
                    ScrollDown?.Invoke();
                    break;
            }
        }
    }
}
