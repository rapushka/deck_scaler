using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    /// One-Frame Entity
    public sealed class RequireSpawnStages : FlagComponent, IInScope<Game> { }

    public sealed class Stage : FlagComponent, IInScope<Game> { }

    public sealed class StageIndex : PrimaryIndexComponent<int>, IInScope<Game> { }

    public sealed class CompletedStage : FlagComponent, IInScope<Game> { }

    public sealed class CurrentStage : FlagComponent, IInScope<Game>, IUnique { }

    /// One-Frame Component
    public sealed class SelectStage : FlagComponent, IInScope<Game> { }

    // # Stage Types
    public sealed class StageType : ValueComponent<DeckScaler.StageType>, IInScope<Game> { }

    public sealed class FightStage : FlagComponent, IInScope<Game> { }

    public sealed class RecruitmentStage : FlagComponent, IInScope<Game> { }

    public sealed class ShopStage : FlagComponent, IInScope<Game> { }
}