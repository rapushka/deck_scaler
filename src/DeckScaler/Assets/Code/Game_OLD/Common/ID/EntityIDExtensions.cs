using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using JetBrains.Annotations;

namespace DeckScaler
{
    public static class EntityIDExtensions
    {
        private static PrimaryEntityIndex<Game, ID, EntityID> Index
            => Contexts.Instance.EntityIDIndex();

        public static PrimaryEntityIndex<Game, ID, EntityID> EntityIDIndex(this Contexts contexts)
            => contexts.Get<Game>().GetPrimaryIndex<ID, EntityID>();

        public static EntityID ID(this Entity<Game> @this) => @this.Get<ID>().Value;

        public static Entity<Game> GetEntity(this EntityID @this) => Index.GetEntity(@this);

        [CanBeNull]
        public static Entity<Game> GetEntityOrDefault(this EntityID @this) => Index.GetEntityOrDefault(@this);

        public static bool TryGetEntity(this EntityID @this, out Entity<Game> entity) => Index.TryGetEntity(@this, out entity);

        public static bool IsEntityDead(this EntityID @this) => @this.GetEntity().Is<Dead>();

        public static Entity<Game> GetByID<TComponent>(this Entity<Game> @this)
            where TComponent : ValueComponent<EntityID>, IInScope<Game>, new()
            => @this.Get<TComponent, EntityID>().GetEntity();

        public static Entity<Game> SetByID<TComponent>(this Entity<Game> @this, Entity<Game> other)
            where TComponent : ValueComponent<EntityID>, IInScope<Game>, new()
        {
            @this.Replace<TComponent, EntityID>(other.Get<ID, EntityID>());
            return @this;
        }
    }
}