using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class AddBoughtTrinketFromShopToInventory : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _boughtUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TrinketInShop>()
                    .And<Bought>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(8);

        private static TrinketsUtil Utils => ServiceLocator.Resolve<IUtils>().Trinket;

        public void Execute()
        {
            foreach (var trinket in _boughtUnits.GetEntities(_buffer))
            {
                Utils.Obtain(trinket);

                CreateEntity.OneFrame()
                    .Add<RearrangeTrinketSlots>();
            }
        }
    }
}