using System.Collections.Generic;
using UnityEngine;

namespace Code.System.Updating
{
    /// <summary>
    /// for updating without MonobBehaior
    /// </summary>
    public class GameUpdate : MonoBehaviour
    {
        private List<IUpdatableObject> _updatableObjects = new();

        public void AddUpdatableObject(IUpdatableObject updatableObject)
        {
            _updatableObjects.Add(updatableObject);
        }

        private void Update()
        {
            for (int i = 0, len = _updatableObjects.Count; i < len; ++i)
            {
                _updatableObjects[i].Update();
            }
        }
    }
}