using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    /// Teammate – it's just a unit, that is in Player's Team
    public sealed class Teammate : FlagComponent, IInScope<Game> { }

    /// If Ally Dies – the game is over
    public sealed class Ally : FlagComponent, IInScope<Game> { }

    public sealed class Lead : FlagComponent, IInScope<Game> { }

    public sealed class Unit : ValueComponent<string>, IInScope<Game>, IEvent<Self> { }

    public sealed class Enemy : FlagComponent, IInScope<Game> { }

    public sealed class OnSide : ValueComponent<Side>, IInScope<Game> { }
}