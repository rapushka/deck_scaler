using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class EntityIDExtensions
    {
        public static EntityModelIDBase ID(this Entity<Model> @this) => (EntityModelIDBase)@this.Get<ID>().Value;

        public static EntityViewIDBase ID(this Entity<View> @this) => (EntityViewIDBase)@this.Get<ID>().Value;
    }
}