using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MakeAllUntypedStagesToFight : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<StageProcessingInProgress>()
                    .Without<Component.StageType>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(8);

        public void Execute()
        {
            foreach (var stage in _stages.GetEntities(_buffer))
                stage.Add<Component.StageType, StageType>(StageType.Fight);
        }
    }
}