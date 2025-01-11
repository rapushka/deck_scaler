using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using JetBrains.Annotations;
using static DeckScaler.Constants;

namespace DeckScaler.Systems
{
    public class SeekForNeighborOpponents : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RecalculateOpponents>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _unitsWithoutOpponents
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Without<Opponent>()
            );
        private readonly IGroup<Entity<Game>> _placedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Without<Dead>()
            );
        private readonly List<Entity<Game>> _buffer = new(128);

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _unitsWithoutOpponents.GetEntities(_buffer))
            {
                var slotIndex = unit.Get<SlotIndex, int>();
                var side = unit.Get<OnSide, Side>();

                var opponent = ClosestOpponent(slotIndex, side);

                if (opponent is not null)
                    unit.SetByID<Opponent>(opponent);
            }
        }

        [CanBeNull]
        private Entity<Game> ClosestOpponent(int slotIndex, Side side)
        {
            int? minDelta = null;
            Entity<Game> closestUnit = null;

            var opponentSide = side.Flip();

            foreach (var entity in _placedUnits.Where(e => e.Get<OnSide, Side>() == opponentSide))
            {
                var index = entity.Get<SlotIndex, int>();
                var signedDelta = index - slotIndex;
                var delta = signedDelta.Abs();
                var isOnLeft = signedDelta.Sign() is Sign.Left;

                if (minDelta is null || minDelta > delta || (minDelta == delta && isOnLeft))
                {
                    minDelta = delta;
                    closestUnit = entity;
                }
            }

            return closestUnit;
        }
    }
}