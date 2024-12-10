using System.Collections.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public class UpdaterBehaviour : MonoBehaviour
    {
        private readonly List<IUpdatable> _updatables = new();

        public void Add(IUpdatable[] updatables) => _updatables.AddRange(updatables);

        public void Clear() => _updatables.Clear();

        private void Update()
        {
            foreach (var updatable in _updatables)
                updatable.UpdateManually();
        }
    }
}