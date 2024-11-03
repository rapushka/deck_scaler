using System.Text;
using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public class ModelEntityFormatter : EntityStringBuilderFormatter<Model>
    {
        protected override void BuildName(ref StringBuilder stringBuilder, in Entity<Model> entity)
        {
            stringBuilder.AppendJoin
            (
                " ",
                entity.creationIndex.ToString(),
                entity.ToString<Name, string>(),
                entity.ToString<Lead>(),

                // Empty symbol just because i have to leave multi-line expression without trailing coma
                "\0"
            );
        }
    }
}