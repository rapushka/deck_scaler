using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SetupShopStage : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<Initializing>()
                    .And<ShopStage>()
                    .Build()
            );

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                stage
                    .Add<UnitInShopCount, int>(Config.Shop.UnitCount)
                    .Add<TrinketInShopCount, int>(Config.Shop.TrinketCount)
                    ;
            }
        }
    }
}