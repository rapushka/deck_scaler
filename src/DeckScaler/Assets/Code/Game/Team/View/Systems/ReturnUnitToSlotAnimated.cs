using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class ReturnUnitToSlotAnimated : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<ReturnToSlot>()
                    .And<WorldPosition>()
                    .And<SlotPosition>()
                    .Build()
            );

        private static UnitViewConfig UnitViewConfig => Services.Get<IConfigs>().UnitView;

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var slotPosition = unit.Get<SlotPosition, Vector2>();
                var duration = UnitViewConfig.ReturnAfterDragDuration;

                unit
                    .Replace<TargetPosition, Vector2>(slotPosition)
                    .Is<AnimateMovement>(true)
                    .Replace<StopAnimatingMovementAfter, Timer>(new(duration))
                    .Replace<AnimationDuration, float>(duration)
                    ;
            }
        }
    }
}