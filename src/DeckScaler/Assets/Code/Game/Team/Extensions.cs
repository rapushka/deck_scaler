using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class TeamSlotExtensions
    {
        public static Entity<Game> SetupToSlotAsTeammate(this Entity<Game> teammate, Entity<Game> slot)
        {
            slot.Replace<HeldTeammate, EntityID>(teammate.ID());
            return teammate.Replace<InSlot, EntityID>(slot.ID());
        }

        public static Entity<Game> SetupToSlotAsEnemy(this Entity<Game> enemy, Entity<Game> slot)
        {
            slot.Replace<HeldEnemy, EntityID>(enemy.ID());
            return enemy.Replace<InSlot, EntityID>(slot.ID());
        }
    }
}