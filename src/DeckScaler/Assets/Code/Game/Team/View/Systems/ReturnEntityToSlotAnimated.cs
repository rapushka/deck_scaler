using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class ReturnEntityToSlotAnimated : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ReturnToSlot>()
                    .And<WorldPosition>()
                    .And<SlotPosition>()
                    .Build()
            );

        private static UnitViewConfig UnitViewConfig => ServiceLocator.Resolve<IConfigs>().UnitView;

        public void Execute()
        {
            foreach (var unit in _entities)
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