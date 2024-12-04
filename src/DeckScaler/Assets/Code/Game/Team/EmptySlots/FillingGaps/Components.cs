using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class FillGapRequest : FlagComponent, IInScope<Game> { }

    public sealed class FillGapAfter : ValueComponent<Timer>, IInScope<Game> { }

    public sealed class FreedSlotIndex : ValueComponent<int>, IInScope<Game> { } //TODO: try remove
    public sealed class FreedSlotSide : ValueComponent<Side>, IInScope<Game> { } //TODO: try remove
}