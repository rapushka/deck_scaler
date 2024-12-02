using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class BaseStats : ValueComponent<StatsData>, IInScope<Game> { }

    public sealed class Health : ValueComponent<int>, IInScope<Game>, IEvent<Self> { }

    public sealed class MaxHealth : ValueComponent<int>, IInScope<Game>, IEvent<Self> { }

    public sealed class Damage : ValueComponent<int>, IInScope<Game>, IEvent<Self> { }

    public sealed class Power : ValueComponent<int>, IInScope<Game>, IEvent<Self> { }
}