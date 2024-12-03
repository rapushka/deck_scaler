using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class FreedSubSlot : ValueComponent<Side>, IInScope<Game> { }

    public sealed class FreedBoth : FlagComponent, IInScope<Game> { }
}