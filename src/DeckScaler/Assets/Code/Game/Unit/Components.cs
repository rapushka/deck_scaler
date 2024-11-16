using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class UnitID : ValueComponent<string>, IInScope<Game>, IEvent { }

    /// Defines the Slot, where the Teammate is
    public sealed class InSlot : ValueComponent<EntityID>, IInScope<Game> { }
}