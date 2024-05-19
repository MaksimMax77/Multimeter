using JetBrains.Annotations;
using UnityEngine;

namespace Code.MaterialsControlling
{
    public class MaterialSwitcher : MonoBehaviour
    {
        [SerializeField] private Material _highLightMaterial;
        [SerializeField] private MeshRenderer _meshRenderer;
        private Material _defaultMaterial;

        private void Awake()
        {
            _defaultMaterial = _meshRenderer.material;
        }

        [UsedImplicitly]
        public void SetMaterial()
        {
            _meshRenderer.material = _highLightMaterial;
        }

        public void SetDefaultMaterial()
        {
            _meshRenderer.material = _defaultMaterial;
        }

        private void OnDisable()
        {
            SetDefaultMaterial();
        }
    }
}
