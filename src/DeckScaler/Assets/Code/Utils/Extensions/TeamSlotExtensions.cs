using System.Collections.Generic;
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
    }
}