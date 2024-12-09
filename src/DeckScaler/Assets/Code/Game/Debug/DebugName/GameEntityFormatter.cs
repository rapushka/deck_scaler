using System.Text;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public class GameEntityFormatter : EntityStringBuilderFormatter<Game>
    {
        protected override void BuildName(ref StringBuilder stringBuilder, in Entity<Game> entity)
        {
            stringBuilder.AppendJoin(
                separator: " ",
                entity.GetOrDefault<ID>()?.Value.ID.ToString() ?? "_",
                entity.ToString<DebugName, string>(),
                entity.ToString<Lead>(),

                // slots
                entity.ToString<SlotIndex, int>(prefix: "in slot: "),

                // Fight Step Changing
                entity.ToString<RequestChangeFightStep, FightStep>(prefix: "change fight step: "),

                // Empty just because I wanna leave multi-line expression with trailing coma
                string.Empty
            );
        }
    }
}