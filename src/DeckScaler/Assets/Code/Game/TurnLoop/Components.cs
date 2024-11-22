using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class EndTurn : FlagComponent, IInScope<Game> { }

    public sealed class TurnEnded : FlagComponent, IInScope<Game> { }

    public sealed class StartEnemyTurn : FlagComponent, IInScope<Game> { }

    /// Stores Opponent's ID
    public sealed class Attack : ValueComponent<EntityID>, IInScope<Game> { }
}