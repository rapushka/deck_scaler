using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using JetBrains.Annotations;

namespace DeckScaler
{
    public class TeamSlotsUtil
    {
        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
                .Build()
        );

        private static PrimaryEntityIndex<Game, TeamSlot, int> Index => Contexts.Instance.TeamSlotIndex();

        public IEnumerable<(Entity<Game>, int)> GetTeamSlotsInOrder()
        {
            var slotCount = _slots.count;

            for (var i = 0; i < slotCount; i++)
            {
                var slot = Index.GetEntity(i);
                yield return (slot, i);
            }
        }

        public IEnumerable<(Entity<Game>, int)> GetTeamSlotsInReversedOrder()
        {
            var slotCount = _slots.count;
            var lastIndex = slotCount - 1;

            for (var i = slotCount - 1; i >= 0; i--)
            {
                var slot = Index.GetEntity(i);
                yield return (slot, lastIndex - i);
            }
        }
    }
}