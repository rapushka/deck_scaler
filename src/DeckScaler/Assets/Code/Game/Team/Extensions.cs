using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Utils
{
    public static class TeamSlotExtensions
    {
        public static Entity<Model> SetupToSlotAsTeammate(this Entity<Model> teammate, Entity<Model> slot)
        {
            slot.Replace<HeldTeammate, Entity<Model>>(teammate);
            return teammate.Replace<InSlot, Entity<Model>>(slot);
        }

        public static Entity<Model> SetupToSlotAsEnemy(this Entity<Model> enemy, Entity<Model> slot)
        {
            slot.Replace<HeldEnemy, Entity<Model>>(enemy);
            return enemy.Replace<InSlot, Entity<Model>>(slot);
        }
    }
}