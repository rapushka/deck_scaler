using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class UnitsConfig
    {
        [field: SerializeField] public ViewConfig View { get; private set; }

        [Serializable]
        public class ViewConfig { }
    }
}