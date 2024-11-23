using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    /// Global Position
    public sealed class WorldPosition : ValueComponent<Vector2>, IInScope<Game> { }

    /// Local Position
    public sealed class Position : ValueComponent<Vector2>, IInScope<Game> { }

    public sealed class LastWorldPosition : ValueComponent<Vector2>, IInScope<Game> { }

    public sealed class ZOrder : ValueComponent<float>, IInScope<Game> { }

    public sealed class ParentTransform : ValueComponent<Transform>, IInScope<Game> { }

    public sealed class ForceChangePositionOnReparent : FlagComponent, IInScope<Game> { }
}