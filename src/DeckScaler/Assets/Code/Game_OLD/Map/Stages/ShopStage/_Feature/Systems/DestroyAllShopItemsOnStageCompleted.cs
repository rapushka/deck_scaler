using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroyAllShopItemsOnStageCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _items
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopItem>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var item in _items)
            {
                item.Add<Destroy>();
            }
        }
    }
}