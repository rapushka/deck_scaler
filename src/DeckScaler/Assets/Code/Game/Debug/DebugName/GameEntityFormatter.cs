using System;
using System.Collections.Generic;
using System.Linq;
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
            var buffer = new[]
            {
                entity.GetOrDefault<ID>()?.Value.ID.ToString() ?? "_",
                entity.ToString<DebugName, string>(),
                entity.ToString<Lead>(),

                // slots
                entity.ToString<SlotIndex, int>(prefix: "in slot: "),

                // turns
                entity.ToString<CurrentTurn, Side>(prefix: "current turn: "),
                entity.ToString<WaitForAnimations>(),
            };

            stringBuilder.AppendJoin(separator: " ", buffer.Where(s => !s.IsEmpty()));
        }
    }
}