using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class CreateEntity
    {
        public static Entity<Game> New()
            => Contexts.Instance.Get<Game>().CreateEntity()
                       .Add<ID, EntityID>(EntityID.Next());
    }
}