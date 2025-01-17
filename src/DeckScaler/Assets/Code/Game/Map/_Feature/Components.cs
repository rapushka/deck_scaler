using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class ShowOnlyInFightStage : FlagComponent, IInScope<Game> { }

    /// One-frame Entity
    public sealed class StageCompletedEvent : FlagComponent, IInScope<Game> { }

    public sealed class Processed : FlagComponent, IInScope<Game> { }

    public sealed class OpenMapAfter : ValueComponent<Timer>, IInScope<Game> { }

    public sealed class RefreshMap : FlagComponent, IInScope<Game> { }
}