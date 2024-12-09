using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TurnTracker : FlagComponent, IInScope<Game> { }

    public sealed class CurrentTurn : ValueComponent<Side>, IInScope<Game> { }

    public sealed class WaitForAnimations : FlagComponent, IInScope<Game> { }

    public sealed class TurnStarted : FlagComponent, IInScope<Game> { }

    public sealed class TurnEnding : FlagComponent, IInScope<Game> { }

    /// One-Frame
    public sealed class RequestEndTurn : FlagComponent, IInScope<Game> { }
}