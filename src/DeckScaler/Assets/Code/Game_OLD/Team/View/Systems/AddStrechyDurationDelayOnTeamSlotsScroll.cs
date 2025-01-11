using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class AddStrechyDurationDelayOnTeamSlotsScroll : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<SlotPosition>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _roots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamRoot>()
                .And<Move>()
                .Build()
        );

        private static TeamSlotViewConfig ViewConfig => ServiceLocator.Resolve<IConfigs>().TeamSlotView;

        public void Execute()
        {
            foreach (var root in _roots)
            foreach (var unit in _units)
            {
                var scrollDirection = root.Get<Move, Vector2>().x.SignInt();
                var slotPosition = unit.Get<SlotPosition, Vector2>().x;

                var distanceFromCenter = -slotPosition * scrollDirection;
                var config = ViewConfig.StretchyScroll;
                var delay = config.DelayAtCenter + config.StepPerDistanceRate * distanceFromCenter;

                unit.Replace<AnimationDuration, float>(delay);
            }
        }
    }
}