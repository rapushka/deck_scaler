using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class DealDamage : ValueComponent<int>, IInScope<Game> { }

    public sealed class Sender : ValueComponent<EntityID>, IInScope<Game> { }

    public sealed class Target : ValueComponent<EntityID>, IInScope<Game> { }
}