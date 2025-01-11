using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Opponent : ValueComponent<EntityID>, IInScope<Game> { }
    
    public sealed class RecalculateOpponents : FlagComponent, IInScope<Game> { }
}