using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class EndTurn : FlagComponent, IInScope<Game> { }

    /// Stores Opponent'sx ID
    public sealed class Attack : ValueComponent<EntityID>, IInScope<Game> { }
}