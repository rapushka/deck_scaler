using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class AssignUnitToEmptySlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _newUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<OnSide>()
                    .Without<SlotIndex>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _placedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<OnSide>()
                    .And<SlotIndex>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var unit in _newUnits.GetEntities(_buffer))
            {
                var side = unit.Get<OnSide, Side>();
                var rightmostIndex = FindRightmostIndex(side);
                rightmostIndex++;

                unit.Add<SlotIndex, int>(rightmostIndex);
            }
        }

        private int FindRightmostIndex(Side side)
        {
            if (!_placedUnits.Any())
                return Constants.TeamSlotsStartingIndex;

            return _placedUnits
                .Where(u => u.Get<OnSide, Side>() == side)
                .MaxOrDefault(u => u.Get<SlotIndex>().Value, defaultValue: Constants.TeamSlotsStartingIndex);
        }
    }
}