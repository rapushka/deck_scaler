using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class Parent : ValueComponent<Transform>, IInScope, IEvent<Self> { }

    public sealed class ViewTransform : ValueComponent<Transform>, IInScope { }
}