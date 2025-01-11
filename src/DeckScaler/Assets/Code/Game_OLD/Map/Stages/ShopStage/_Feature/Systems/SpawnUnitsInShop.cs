using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SpawnUnitsInShop : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _shops
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RestockShop>()
                    .And<UnitInShopCount>()
            );

        private static IUnitFactory Factory => ServiceLocator.Resolve<IFactories>().Unit;

        private static UnitsUtil Utils => ServiceLocator.Resolve<IUtils>().Units;

        public void Execute()
        {
            foreach (var shop in _shops)
            {
                var unitCount = shop.Get<UnitInShopCount, int>();

                foreach (var id in Utils.GetRandomAllyIDs(unitCount))
                    Factory.CreateUnit(id)
                        .Add<UnitInShop>()
                        .Add<ShopItem>()
                        ;
            }
        }
    }
}