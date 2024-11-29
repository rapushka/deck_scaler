using System.Collections.Generic;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Utils
{
    public static class TeamSlotExtensions
    {
        public static IEnumerable<(Entity<Game>, int)> GetTeamSlotsInOrder(this IGroup<Entity<Game>> slots)
        {
            var entityIndex = Contexts.Instance.TeamSlotIndex();
            var slotCount = slots.count;

            for (var i = 0; i < slotCount; i++)
            {
                var slot = entityIndex.GetEntity(i);
                yield return (slot, i);
            }
        }

        public static IEnumerable<(Entity<Game>, int)> GetTeamSlotsInReversedOrder(this IGroup<Entity<Game>> slots)
        {
            var entityIndex = Contexts.Instance.TeamSlotIndex();
            var slotCount = slots.count;
            var lastIndex = slotCount - 1;

            for (var i = slotCount - 1; i >= 0; i--)
            {
                var slot = entityIndex.GetEntity(i);
                yield return (slot, lastIndex - i);
            }
        }
    }
}