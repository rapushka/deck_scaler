using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class AddStrechyDurationDelayOnTeamSlotsScroll : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _roots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamRoot>()
                .And<Move>()
                .Build()
        );

        private static TeamSlotViewConfig ViewConfig => Services.Get<IConfigs>().TeamSlotView;

        public void Execute()
        {
            foreach (var root in _roots)
            foreach (var slot in _slots)
            {
                var direction = root.Get<Move, Vector2>().x.SignInt();
                var slotPosition = slot.Get<WorldPosition, Vector2>().x;

                var distanceFromCenter = -slotPosition * direction;
                var config = ViewConfig.StretchyScroll;
                var delay = config.DelayAtCenter + config.StepPerDistanceRate * distanceFromCenter;

                slot.Replace<AnimationDuration, float>(delay);
            }
        }
    }
}