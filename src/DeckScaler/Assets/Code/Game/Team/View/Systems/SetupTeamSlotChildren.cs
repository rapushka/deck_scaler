using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class SetupTeamSlotChildren : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamSlot>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var slots in _slots)
            {
                Reparent<HeldTeammate, TeammateTransform>(slots);
                Reparent<HeldEnemy, EnemyTransform>(slots);
            }
        }

        private static void Reparent<THeldComponent, TTransformComponent>(Entity<Game> slots)
            where THeldComponent : ValueComponent<EntityID>, IInScope<Game>, new()
            where TTransformComponent : ValueComponent<Transform>, IInScope<Game>, new()
        {
            if (slots.TryGet<THeldComponent, EntityID>(out var heldUnit))
            {
                var container = slots.Get<TTransformComponent>().Value;

                heldUnit.GetEntity()
                        .Replace<ParentTransform, Transform>(container)
                        .Is<ForceChangePositionOnReparent>(true)
                    ;
            }
        }
    }
}