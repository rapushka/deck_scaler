using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Component
{
    public sealed class WorldPosition : ValueComponent<Vector2>, IInScope<Game>, IInScope<Input> { }

    public sealed class LocalPosition : ValueComponent<Vector2>, IInScope<Game> { }

    public sealed class LastWorldPosition : ValueComponent<Vector2>, IInScope<Game> { } // TODO: may remove?

    public sealed class LastLocalPosition : ValueComponent<Vector2>, IInScope<Game> { } // TODO: may remove?

    public sealed class ZOrder : ValueComponent<float>, IInScope<Game> { }

    public sealed class ParentTransform : ValueComponent<Transform>, IInScope<Game> { }

    public sealed class ForceChangePositionOnReparent : FlagComponent, IInScope<Game> { }
}