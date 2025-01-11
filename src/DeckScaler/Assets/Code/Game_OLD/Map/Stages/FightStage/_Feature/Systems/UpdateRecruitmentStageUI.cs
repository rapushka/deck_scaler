using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class UpdateFightStageStageUI : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _newStages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<SelectStage>()
            );
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShowOnlyInFightStage>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var stage in _newStages)
            foreach (var entity in _entities)
            {
                var isFightStage = stage.Is<FightStage>();
                entity.Is<Visible>(isFightStage);
            }
        }
    }
}