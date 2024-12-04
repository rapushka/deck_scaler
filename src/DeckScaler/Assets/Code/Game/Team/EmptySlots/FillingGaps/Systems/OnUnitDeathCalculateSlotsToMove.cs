using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnUnitDeathCalculateSlotsToMove : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _diedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<JustDied>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _placedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Without<Dead>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var diedUnit in _diedUnits)
            {
                var freedIndex = diedUnit.Get<SlotIndex, int>();
                var freedSide = diedUnit.Get<OnSide, Side>();

                foreach (var placedUnit in _placedUnits)
                {
                    if (placedUnit.Get<OnSide, Side>() != freedSide)
                        continue;

                    if (placedUnit.Get<SlotIndex, int>() <= freedIndex)
                        continue;

                    var alreadyMovedFor = placedUnit.GetOrDefault<MoveSlotToLeft, int>();
                    placedUnit.Replace<MoveSlotToLeft, int>(alreadyMovedFor + 1);
                }
            }
        }
    }
}