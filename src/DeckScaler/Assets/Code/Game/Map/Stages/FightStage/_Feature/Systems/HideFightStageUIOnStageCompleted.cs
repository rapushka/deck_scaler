using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class HideFightStageUIOnStageCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Without<Processed>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShowOnlyInFightStage>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var entity in _entities)
                entity.Is<Visible>(false);
        }
    }
}