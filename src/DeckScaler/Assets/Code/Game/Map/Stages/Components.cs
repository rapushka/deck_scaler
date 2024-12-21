using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    /// One-Frame
    public sealed class RequireSpawnStages : FlagComponent, IInScope<Game> { }

    public sealed class Stage : FlagComponent, IInScope<Game> { }

    public sealed class StageType : ValueComponent<DeckScaler.StageType>, IInScope<Game> { }

    public sealed class StageIndex : ValueComponent<int>, IInScope<Game> { }

    public sealed class CompletedStage : FlagComponent, IInScope<Game> { }

    public sealed class CurrentStage : FlagComponent, IInScope<Game>, IUnique { }
}