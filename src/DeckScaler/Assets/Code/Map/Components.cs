using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class SelectNextLevel : FlagComponent, IInScope<Game> { }

    public sealed class HideMeWhenMapOpened : FlagComponent, IInScope<Game> { }

    public sealed class SendLevelCompletedAfter : ValueComponent<Timer>, IInScope<Game> { }
}