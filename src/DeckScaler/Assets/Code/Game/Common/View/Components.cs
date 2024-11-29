using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class View : ValueComponent<EntityBehaviour<Game>>, IInScope<Game> { }

    public sealed class ViewTransform : ValueComponent<Transform>, IInScope<Game> { }

    public sealed class ZOrder : ValueComponent<float>, IInScope<Game> { }

    public sealed class ParentTransform : ValueComponent<Transform>, IInScope<Game> { }

    public sealed class ForceChangePositionOnReparent : FlagComponent, IInScope<Game> { }
}