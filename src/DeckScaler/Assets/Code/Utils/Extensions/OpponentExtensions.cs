using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class OpponentExtensions
    {
        public static bool TryGetOpponent(this Entity<Game> @this, out EntityID opponentID)
        {
            var slot = @this.Get<InSlot>().Value.GetEntity();

            return @this.Is<Teammate>()
                ? slot.TryGet<HeldEnemy, EntityID>(out opponentID)
                : slot.TryGet<HeldTeammate, EntityID>(out opponentID);
        }
    }
}