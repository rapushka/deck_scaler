using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Stage : ValueComponent<StageType>, IInScope<Game> { }

    public sealed class StageIndex : ValueComponent<int>, IInScope<Game> { }

    public sealed class StageCompleted : FlagComponent, IInScope<Game> { }

    public sealed class CurrentStage : ValueComponent<int>, IInScope<Game>, IUnique { }
}