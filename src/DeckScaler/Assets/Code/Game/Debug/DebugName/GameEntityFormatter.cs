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
                entity.ToString<ID, EntityID>(),
                entity.ToString<Name, string>(),
                entity.ToString<Lead>(),
                entity.ToString<RequestChangeFightStep, FightStep>(prefix: "change fight step: "),

                // Empty just because I wanna leave multi-line expression with trailing coma
                string.Empty
            );
        }
    }
}