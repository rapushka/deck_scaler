using System.Text;
using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public class ViewEntityFormatter : EntityStringBuilderFormatter<View>
    {
        protected override void BuildName(ref StringBuilder stringBuilder, in Entity<View> entity)
        {
            stringBuilder.AppendJoin
            (
                " ",
                entity.ToString<ID, EntityIDBase>(),
                entity.ToString<Name, string>(),

                // Empty symbol just because I wanna leave multi-line expression without trailing coma
                "\0"
            );
        }
    }
}