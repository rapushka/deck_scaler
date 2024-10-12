using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class Portrait : ValueComponent<Sprite>, IInScope, IEvent<Self> { }

    public sealed class ViewTransform : ValueComponent<Transform>, IInScope { }
}