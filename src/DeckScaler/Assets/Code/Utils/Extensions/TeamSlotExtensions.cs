using System;
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

        public static EntityID GetUnitFromSide(this Entity<Game> slot, Side side)
        {
            if (side is Side.Enemy)
                return slot.Get<HeldEnemy, EntityID>();

            if (side is Side.Player)
                return slot.Get<HeldTeammate, EntityID>();

            throw new ArgumentException("Side is unknown:(");
        }

        public static bool TryGetUnitFromSide(this Entity<Game> slot, Side side, out EntityID unitID)
        {
            if (side is Side.Enemy)
                return slot.TryGet<HeldEnemy, EntityID>(out unitID);

            if (side is Side.Player)
                return slot.TryGet<HeldTeammate, EntityID>(out unitID);

            throw new ArgumentException("Side is unknown:(");
        }
    }
}