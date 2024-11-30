using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class PlayUnitAppearAnimation : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<WorldPosition>()
                    .Without<AutoPlaceInSlot>()
                    .Without<TargetPosition>()
                    .Without<PlayingAnimation>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        private static TeamSlotViewConfig ViewConfig => Services.Get<IConfigs>().TeamSlotView;

        private static UnitViewConfig UnitViewConfig => Services.Get<IConfigs>().UnitView;

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var offset = unit.Is<Teammate>() ? ViewConfig.TeammateInSlotOffset : ViewConfig.EnemyInSlotOffset;

                var slot = unit.Get<InSlot, EntityID>().GetEntity();
                var slotPosition = slot.Get<WorldPosition, Vector2>();

                var duration = UnitViewConfig.AppearDuration;

                var targetPosition = slotPosition + offset;
                unit
                    .Replace<TargetPosition, Vector2>(targetPosition)
                    .Is<AnimateMovement>(true)
                    .Add<StopAnimatingMovementAfter, Timer>(new Timer(duration))
                    .Replace<AnimationDuration, float>(duration)
                    ;
            }
        }
    }
}