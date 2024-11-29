using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler.Utils;
using DG.Tweening;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class AddStrechyDurationDelayOnTeamSlotsScroll : IExecuteSystem // TODO: REMOVE? - nah
    {
        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _roots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamRoot>()
                .Build()
        );

        private static TeamSlotViewConfig ViewConfig => Services.Get<IConfigs>().TeamSlotView;

        public void Execute()
        {
            foreach (var root in _roots)
            {
                // var rootPosition = root.Get<WorldPosition, Vector2>().x;
                var direction = root.GetOrDefault<Move, Vector2>().x.SignInt();
                if (direction == 0)
                    continue;

                var movingLeft = direction == -1;

                var slots = movingLeft ? _slots.GetTeamSlotsInOrder() : _slots.GetTeamSlotsInReversedOrder(); // TODO: if don't use index - just iterate through group, without using EntityIndex
                foreach (var (slot, index) in slots)
                {
                    var slotPosition = slot.Get<WorldPosition, Vector2>().x;
                    var distanceFromCenter = -slotPosition * direction;

                    var config = ViewConfig.StretchyScroll;
                    var delay = config.DelayAtCenter + config.StepPerDistanceRate * distanceFromCenter;
                    // var delay = ViewConfig.StretchyScrollDelayStep * distanceFromRoot + ViewConfig.StretchyScrollStartingDelay;

                    // DOTween.To(
                    //     getter: () => slot.GetOrDefault<AnimationDuration, float>(),
                    //     setter: (v) => slot.Replace<AnimationDuration, float>(v),
                    //     endValue: delay,
                    //     ViewConfig.StretchyScrollLerp
                    // );

                    slot.Replace<AnimationDuration, float>(delay);
                }
            }
        }
    }
}