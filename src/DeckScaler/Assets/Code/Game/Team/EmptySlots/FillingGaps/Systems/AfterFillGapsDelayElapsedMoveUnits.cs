using System.Collections.Generic;
using System.Linq;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class AfterFillGapsDelayElapsedMoveUnits : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _fillRequests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<FillGapRequest>()
                    .And<FillGapAfter>()
                    .And<FreedSlotIndex>()
                    .And<FreedSlotSide>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var request in _fillRequests)
            {
                if (!request.Get<FillGapAfter, Timer>().IsElapsed)
                    continue;

                var index = request.Get<FreedSlotIndex>().Value;
                var side = request.Get<FreedSlotSide>().Value;

                foreach (var unit in _units.GetEntities(_buffer).Where(OnSameSideAndOnRight))
                    unit.Increment<SlotIndex>(-1);

                continue;

                bool OnSameSideAndOnRight(Entity<Game> unit)
                    => unit.Get<OnSide, Side>() == side
                        && unit.Get<SlotIndex, int>() > index;
            }
        }
    }
}