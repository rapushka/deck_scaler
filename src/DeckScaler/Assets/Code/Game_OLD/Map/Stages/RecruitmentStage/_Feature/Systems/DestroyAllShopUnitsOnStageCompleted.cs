using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroyAllRecruitsOnStageCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _recruits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RecruitmentCandidate>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var recruit in _recruits)
            {
                recruit.Add<Destroy>();
            }
        }
    }
}