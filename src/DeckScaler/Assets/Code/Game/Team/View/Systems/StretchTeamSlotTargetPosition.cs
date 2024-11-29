using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class StretchTeamSlotTargetPosition : IExecuteSystem
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
                var direction = root.GetOrDefault<Move, Vector2>().x.SignInt();
                if (direction == 0)
                    continue;

                var movingLeft = direction == -1;

                var slots = movingLeft ? _slots.GetTeamSlotsInOrder() : _slots.GetTeamSlotsInReversedOrder();
                foreach (var (slot, index) in slots)
                {
                    if (!slot.Has<TargetPosition>())
                        continue;

                    var currentPosition = slot.Get<WorldPosition, Vector2>().x;
                    var targetPosition = slot.Get<TargetPosition, Vector2>();
                    var targetX = targetPosition.x;

                    var t = (float)index / _slots.count;
                    var x = Mathf.Lerp(targetX, currentPosition, t * ViewConfig.StretchyScrollMult + ViewConfig.StretchyScrollAdd);
                    slot.Replace<TargetPosition, Vector2>(targetPosition.With(x: x));
                }
            }
        }
    }
}