using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class Parent : ValueComponent<Transform>, IInScope<View>, IEvent<Self> { }

    public sealed class ViewTransform : ValueComponent<Transform>, IInScope<View> { }

    public sealed class ViewEntity : ValueComponent<EntityViewIDBase>, IInScope<Model> { }

    public sealed class ModelEntity : ValueComponent<EntityModelIDBase>, IInScope<View> { }
}