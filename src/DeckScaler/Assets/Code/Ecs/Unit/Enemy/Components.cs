using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Enemy : FlagComponent, IInScope { }

    public sealed class Opponent : ValueComponent<Entity<Scope>>, IEvent<Self>, IInScope { }
}