using DeckScaler.Scopes;
using DG.Tweening;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class UnitAnimator : ValueComponent<DeckScaler.UnitAnimator>, IInScope<Game> { }

    public sealed class PlayingAnimation : ValueComponent<Tween>, IInScope<Game> { }

    public sealed class PlayingAttackAnimation : FlagComponent, IInScope<Game> { }
}