using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public static class TeamSlotExtensions
    {
        public static PrimaryEntityIndex<Game, TeamSlot, int> TeamSlotIndex(this Contexts contexts)
            => contexts.Get<Game>().GetPrimaryIndex<TeamSlot, int>();

        public static Entity<Game> SetupTeammateToSlot(this Entity<Game> teammate, Entity<Game> slot)
        {
            slot.Replace<HeldTeammate, EntityID>(teammate.ID());
            return teammate.Replace<InSlot, EntityID>(slot.ID());
        }

        public static Entity<Game> SetupEnemyToSlot(this Entity<Game> enemy, Entity<Game> slot)
        {
            slot.Replace<HeldEnemy, EntityID>(enemy.ID());
            return enemy.Replace<InSlot, EntityID>(slot.ID());
        }
    }
}