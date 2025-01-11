using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroySingleUseTrinketsAfterUse : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _droppedTrinkets
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Trinket>()
                    .And<Used>()
                    .And<SingleUseTrinket>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var trinket in _droppedTrinkets)
                trinket.Add<Destroy>();
        }
    }
}