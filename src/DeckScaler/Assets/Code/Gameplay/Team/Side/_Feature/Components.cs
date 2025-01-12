using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class OnSide : ValueComponent<Side>, IInScope<Game> { }
}