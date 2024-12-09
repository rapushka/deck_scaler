using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TurnTracker : FlagComponent, IInScope<Game> { }

    public sealed class CurrentTurn : ValueComponent<Side>, IInScope<Game> { }

    public sealed class WaitingForAnimations : FlagComponent, IInScope<Game> { }

    public sealed class TurnStarted : FlagComponent, IInScope<Game> { }

    public sealed class FinishingTurn : FlagComponent, IInScope<Game> { }

    public sealed class TurnJustEnded : FlagComponent, IInScope<Game> { }

    /// One-Frame
    public sealed class RequestEndTurn : FlagComponent, IInScope<Game> { }
}