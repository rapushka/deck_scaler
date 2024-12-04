using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class FillGapAfter : ValueComponent<Timer>, IInScope<Game> { }

    public sealed class MoveSlotToLeft : ValueComponent<int>, IInScope<Game> { }
}