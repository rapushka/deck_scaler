using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class RecruitmentCandidate : FlagComponent, IInScope<Game> { }

    public sealed class RecruitOnStageCount : ValueComponent<int>, IInScope<Game> { }
}