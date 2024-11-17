using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class EntityIDExtensions
    {
        public static EntityID ID(this Entity<Game> @this) => @this.Get<ID>().Value;
    }
}