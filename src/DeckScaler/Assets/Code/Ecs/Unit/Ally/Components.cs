using Entitas.Generic;

namespace DeckScaler.Component
{
    /// Teammate – it's just a unit, that is in Player's Team
    public sealed class Teammate : FlagComponent, IInScope<Model> { }

    /// If Ally Dies – the game is over
    public sealed class Ally : FlagComponent, IInScope<Model> { }
}