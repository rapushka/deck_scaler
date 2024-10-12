using System.Collections.Generic;
using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public class Formatter : EntityComponentsListFormatter<Scope>
    {
        protected override IEnumerable<string> CreateList(Entity<Scope> entity)
        {
            yield return entity.creationIndex.ToString();

            yield return entity.ToString<Name, string>();

            yield return entity.ToString<Lead>();
        }
    }
}