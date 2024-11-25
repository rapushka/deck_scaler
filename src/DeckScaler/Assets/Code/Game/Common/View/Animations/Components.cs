using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    /// Local Position
    public sealed class TargetPosition : ValueComponent<Vector2>, IInScope<Game> { }

    public sealed class Easing : ValueComponent<AnimationCurve>, IInScope<Game> { }

    public sealed class AnimationDuration : ValueComponent<float>, IInScope<Game> { }
}