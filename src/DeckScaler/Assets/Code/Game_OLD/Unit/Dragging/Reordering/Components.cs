using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    /// The TeamSlot where the dragged Unit will be placed on drop
    public sealed class ClosestSlotForReorder : FlagComponent, IInScope<Game> { }
}