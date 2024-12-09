using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class AppearUnitToSlotAnimated : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<WorldPosition>()
                    .And<SlotPosition>()
                    .Without<Appeared>()
                    .Without<SittingInSlot>()
                    .Without<TargetPosition>()
                    .Without<PlayingAnimation>()
                    .Without<Dragging>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        private static UnitViewConfig UnitViewConfig => ServiceLocator.Resolve<IConfigs>().UnitView;

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var duration = UnitViewConfig.AppearDuration;

                var slotPosition = unit.Get<SlotPosition, Vector2>();
                var startPosition = unit.Get<WorldPosition, Vector2>().With(x: slotPosition.x);

                unit
                    .Replace<WorldPosition, Vector2>(startPosition)
                    .Replace<TargetPosition, Vector2>(slotPosition)
                    .Is<AnimateMovement>(true)
                    .Replace<StopAnimatingMovementAfter, Timer>(new(duration))
                    .Replace<AnimationDuration, float>(duration)
                    ;
            }
        }
    }
}