using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class DestroyAllShopUnitsOnStageCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitInShop>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _units)
            {
                unit.Add<Destroy>();
            }
        }
    }
}