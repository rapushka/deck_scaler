using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UseDroppedTrinket : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _droppedTrinkets
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Trinket>()
                    .And<Dropped>()
                    .And<WorldPosition>()
                    .And<TrinketAbility>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<WorldPosition>()
                    .Build()
            );

        private static AllTrinketsConfig Config => ServiceLocator.Resolve<IConfigs>().Trinkets;

        private static IAffectsFactory AffectFactory => ServiceLocator.Resolve<IFactories>().Affects;

        public void Execute()
        {
            var useRange = Config.DroppedTrinketUseRange;

            foreach (var trinket in _droppedTrinkets)
            {
                var trinketPosition = trinket.Get<WorldPosition, Vector2>();

                foreach (var unit in _units)
                {
                    var unitPosition = unit.Get<WorldPosition, Vector2>();

                    var distanceToUnit = trinketPosition.DistanceTo(unitPosition);
                    if (distanceToUnit <= useRange)
                    {
                        var trinketAbility = trinket.Get<TrinketAbility, AffectData>();

                        AffectFactory.Create(
                            data: trinketAbility,
                            senderID: trinket.ID(),
                            targetID: unit.ID()
                        );

                        trinket.Add<Used>();

                        return;
                    }
                }
            }
        }
    }
}