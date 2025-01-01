using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class TryBuyOnUnitInShopClicked : IExecuteSystem
    {
        private readonly IGroup<Entity<Input>> _hoveredEntities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<HoveredEntity>()
                    .Build()
            );
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .And<CursorClicked>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var hovered in _hoveredEntities)
            foreach (var _ in _cursors)
            {
                var entity = hovered.Get<HoveredEntity>().Value.GetEntity();

                if (!entity.Is<UnitInShop>())
                    continue;

                entity.Add<TryBuy>();
            }
        }
    }
}