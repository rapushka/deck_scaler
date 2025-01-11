using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class AddBoughtUnitFromShopToTeam : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _boughtUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitInShop>()
                    .And<Bought>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(8);

        private static UnitsUtil Utils => ServiceLocator.Resolve<IUtils>().Units;

        public void Execute()
        {
            foreach (var recruit in _boughtUnits.GetEntities(_buffer))
                Utils.TakeToTeam(recruit);
        }
    }
}