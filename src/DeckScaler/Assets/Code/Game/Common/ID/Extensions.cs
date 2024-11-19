using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class EntityIDExtensions
    {
        private static PrimaryEntityIndex<Game, ID, EntityID> Index
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<ID, EntityID>();

        public static EntityID ID(this Entity<Game> @this) => @this.Get<ID>().Value;

        public static Entity<Game> GetEntity(this EntityID @this) => Index.GetEntity(@this);
    }
}