using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class ArrangeTeamSlots : FlagComponent, IInScope<Game> { }

    public sealed class AutoArrangeInSlot : FlagComponent, IInScope<Game> { }
}