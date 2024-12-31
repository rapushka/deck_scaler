using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class PlayerInventory : FlagComponent, IInScope<Game> { }

    public sealed class Inventory : PrimaryIndexComponent<Side>, IInScope<Game> { }

    public sealed class Money : ValueComponent<int>, IInScope<Game>, IEvent<Self> { }

    public sealed class Price : ValueComponent<int>, IInScope<Game> { }
}