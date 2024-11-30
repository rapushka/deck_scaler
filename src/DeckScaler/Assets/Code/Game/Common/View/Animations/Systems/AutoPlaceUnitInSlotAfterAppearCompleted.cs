using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class AutoPlaceUnitInSlotAfterAppearCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StopAnimatingMovementAfter>()
                    .And<UnitID>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                if (unit.Get<StopAnimatingMovementAfter, Timer>().IsElapsed)
                    unit.Is<AutoPlaceInSlot>(true);
            }
        }
    }
}