using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class TeamSlotExtensions
    {
        public static Entity<Model> SetupToSlotAsTeammate(this Entity<Model> teammate, Entity<Model> slot)
        {
            slot.Replace<HeldTeammate, EntityModelIDBase>(teammate.ID());
            return teammate.Replace<InSlot, EntityModelIDBase>(slot.ID());
        }

        public static Entity<Model> SetupToSlotAsEnemy(this Entity<Model> enemy, Entity<Model> slot)
        {
            slot.Replace<HeldEnemy, EntityModelIDBase>(enemy.ID());
            return enemy.Replace<InSlot, EntityModelIDBase>(slot.ID());
        }
    }
}