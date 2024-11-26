using System.Collections.Generic;
using System.Transactions;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

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
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .Without<Opponent>()
            );
        private readonly List<Entity<Game>> _buffer = new(128);

        private static PrimaryEntityIndex<Game, TeamSlot, int> Index => Contexts.Instance.TeamSlotIndex();

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var slot = unit.Get<InSlot>().Value.GetEntity();
                var currentIndex = slot.Get<TeamSlot>().Value;

                var delta = 1;

                var loop = EndlessLoopPreventor.New();
                while (loop.Continue)
                {
                    var left = currentIndex - delta;
                    var resultFromLeft = TryGetFrom(left, unit);
                    if (resultFromLeft is Result.Success)
                        break;

                    var right = currentIndex + delta;
                    var resultFromRight = TryGetFrom(right, unit);
                    if (resultFromRight is Result.Success)
                        break;

                    if (resultFromLeft is Result.NoSlot
                        && resultFromRight is Result.NoSlot)
                        break;

                    delta++;
                }
            }
        }

        private static Result TryGetFrom(int index, Entity<Game> unit)
        {
            if (!Index.TryGetEntity(index, out var targetSlot))
                return Result.NoSlot;

            var opponent = unit.Is<Teammate>()
                ? targetSlot.GetOrDefault<HeldEnemy>()?.Value
                : targetSlot.GetOrDefault<HeldTeammate>()?.Value;

            if (opponent is not null && !opponent.Value.GetEntity().Is<Dead>())
            {
                unit.Add<Opponent, EntityID>(opponent.Value);
                return Result.Success;
            }

            return Result.SlotIsEmpty;
        }

        private enum Result
        {
            NoSlot,
            SlotIsEmpty,
            Success,
        }
    }
}