using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TrinketSlot : ValueComponent<int>, IInScope<Game> { }

    public sealed class RearrangeTrinketSlots : FlagComponent, IInScope<Game> { }
}