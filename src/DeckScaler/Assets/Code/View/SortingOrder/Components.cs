using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class SpriteSortOrder : ValueComponent<int>, IInScope<Game>, IEvent<Self> { }
}