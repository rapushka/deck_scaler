using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    /// Stores Opponent's ID
    public sealed class PrepareAttack : ValueComponent<EntityID>, IInScope<Game> { }

    public sealed class TimerBeforeAttack : ValueComponent<Timer>, IInScope<Game> { }
}