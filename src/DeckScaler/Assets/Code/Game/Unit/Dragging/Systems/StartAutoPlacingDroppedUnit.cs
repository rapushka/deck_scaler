using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class StartAutoPlacingDroppedUnit : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _droppedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dropped>()
                    .And<UnitID>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var unit in _droppedUnits)
            {
                unit
                    .Is<AutoPlaceInSlot>(true)
                    .Is<AnimateMovement>(true)
                    ;
            }
        }
    }
}