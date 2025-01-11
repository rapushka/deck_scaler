using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MarkUnitAppearedAfterAnimatedMovementCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StopAnimatingMovementAfter>()
                    .And<Unit>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                if (!unit.Get<StopAnimatingMovementAfter, Timer>().IsElapsed)
                    continue;

                unit
                    .Is<SittingInSlot>(true)
                    .Is<Appeared>(true)
                    ;
            }
        }
    }
}