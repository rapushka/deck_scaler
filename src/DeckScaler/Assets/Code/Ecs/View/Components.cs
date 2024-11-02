using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class Parent : ValueComponent<Transform>, IInScope<Model>, IEvent<Self> { }

    public sealed class ViewTransform : ValueComponent<Transform>, IInScope<Model>{ }
}