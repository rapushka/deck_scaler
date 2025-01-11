using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class HideFightStageUIOnInit : IInitializeSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShowOnlyInFightStage>()
                    .Build()
            );

        public void Initialize()
        {
            foreach (var entity in _entities)
            {
                entity.Is<Visible>(true);  // TBD: #174
                entity.Is<Visible>(false); // TBD: #174
            }
        }
    }
}