using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnRequireSpawnStagesDestroyOldStages : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RequireSpawnStages>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _oldStages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _requests)
            foreach (var stage in _oldStages)
            {
                stage.Is<Destroy>(true);
            }
        }
    }
}