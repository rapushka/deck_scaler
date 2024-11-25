using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Enemy : FlagComponent, IInScope<Game> { }

    public sealed class Opponent : ValueComponent<EntityID>, IInScope<Game> { }
}