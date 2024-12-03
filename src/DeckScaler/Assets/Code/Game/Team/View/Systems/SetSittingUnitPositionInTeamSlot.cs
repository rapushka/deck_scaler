using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class SetSittingUnitPositionInTeamSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<WorldPosition>()
                    .And<SlotPosition>()
                    .And<SittingInSlot>()
                    .And<Appeared>()
                    .Without<AnimateMovement>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var slotPosition = unit.Get<SlotPosition, Vector2>();
                unit.Replace<WorldPosition, Vector2>(slotPosition);
            }
        }
    }
}