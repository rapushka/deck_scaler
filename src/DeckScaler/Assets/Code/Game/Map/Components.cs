using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class HideMeWhenMapOpened : FlagComponent, IInScope<Game> { }

    public sealed class LevelCompleted : FlagComponent, IInScope<Game> { }

    public sealed class Processed : FlagComponent, IInScope<Game> { }

    public sealed class OpenMapAfter : ValueComponent<Timer>, IInScope<Game> { }

    public sealed class RefreshMap : FlagComponent, IInScope<Game> { }
}