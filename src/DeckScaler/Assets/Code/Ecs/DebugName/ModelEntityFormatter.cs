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
                entity.ToString<ID, EntityIDBase>(),
                entity.ToString<Name, string>(),
                entity.ToString<Lead>(),

                // Empty symbol just because I wanna leave multi-line expression without trailing coma
                "\0"
            );
        }
    }
}