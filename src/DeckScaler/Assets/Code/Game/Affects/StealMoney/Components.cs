using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class StealMoney : ValueComponent<int>, IInScope<Game> { }

    public sealed class StealMoneyFrom : ValueComponent<Side>, IInScope<Game> { }
}