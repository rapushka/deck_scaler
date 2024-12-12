using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TrinketSlot : PrimaryIndexComponent<int>, IInScope<Game> { }

    public sealed class TrinketInSlot : PrimaryIndexComponent<int>, IInScope<Game> { }

    public sealed class RearrangeTrinketSlots : FlagComponent, IInScope<Game> { }
}