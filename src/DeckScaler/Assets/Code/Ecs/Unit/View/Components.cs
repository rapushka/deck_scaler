using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class Portrait : ValueComponent<Sprite>, IInScope<View>, IEvent<Self> { }
}