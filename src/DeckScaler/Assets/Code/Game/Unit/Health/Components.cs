using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Health : ValueComponent<int>, IInScope<Game> { }

    public sealed class MaxHealth : ValueComponent<int>, IInScope<Game> { }
}