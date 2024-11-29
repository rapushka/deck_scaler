using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class PlaceUnitsInTeamSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<WorldPosition>()
                    .And<AutoPlaceInSlot>()
                    .Build()
            );

        private static TeamSlotViewConfig ViewConfig => Services.Get<IConfigs>().TeamSlotView;

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var offset = unit.Is<Teammate>() ? ViewConfig.TeammateInSlotOffset : ViewConfig.EnemyInSlotOffset;

                var slot = unit.Get<InSlot, EntityID>().GetEntity();
                var slotPosition = slot.Get<WorldPosition, Vector2>();

                unit.Replace<WorldPosition, Vector2>(slotPosition + offset);
            }
        }
    }
}