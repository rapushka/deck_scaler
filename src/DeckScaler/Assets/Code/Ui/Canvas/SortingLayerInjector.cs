using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;

namespace DeckScaler
{
    public class SortingLayerInjector : MonoBehaviour
    {
        [SortingLayer]
        [SerializeField] private string _layer;
        [SerializeField] private bool _setOnAwake = true;

        [HideInInspector]
        [SerializeField] private Canvas[] _canvases = { };

        [HideInInspector]
        [SerializeField] private Renderer[] _renderers = { };

        private void Awake()
        {
            if (_setOnAwake)
                Set();
        }

        [Button, UsedImplicitly]
        public void CollectAndSet()
        {
            Collect();
            Set();
        }

        private void Collect()
        {
            _canvases = GetComponents<Canvas>();
            _renderers = GetComponents<Renderer>();
        }

        private void Set()
        {
            foreach (var canvas in _canvases)
                canvas.sortingLayerName = _layer;

            // ReSharper disable once LocalVariableHidesMember - fuck you, unity
            foreach (var renderer in _renderers)
                renderer.sortingLayerName = _layer;
        }
    }
}