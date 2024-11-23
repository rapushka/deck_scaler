using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class Portrait : ValueComponent<SpriteRenderer>, IInScope<Game> { }

    public sealed class CardBackground : ValueComponent<SpriteRenderer>, IInScope<Game> { }

    public sealed class UnitAnimator : ValueComponent<DeckScaler.UnitAnimator>, IInScope<Game> { }
}