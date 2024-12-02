using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Suit : ValueComponent<DeckScaler.Suit>, IInScope<Game>, IEvent<Self> { }
}