using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SpawnUnitsInShop : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopStage>()
                    .And<SelectStage>()
                    .And<UnitInShopCount>()
            );

        private static IUnitFactory Factory => ServiceLocator.Resolve<IFactories>().Unit;

        private static UnitsUtil Utils => ServiceLocator.Resolve<IUtils>().Units;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                var unitCount = stage.Get<UnitInShopCount, int>();

                foreach (var id in Utils.GetRandomAllyIDs(unitCount))
                    Factory.CreateUnit(id)
                        .Add<UnitInShop>()
                        .Add<ShopItem>()
                        ;
            }
        }
    }
}