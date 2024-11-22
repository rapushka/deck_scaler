using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class CreateEntity
    {
        public static Entity<Game> Next()
            => Contexts.Instance.Get<Game>().CreateEntity()
                       .Add<ID, EntityID>(EntityID.Next());

        public static Entity<Game> OneFrame()
            => Contexts.Instance.Get<Game>().CreateEntity()
                       .Is<Destroy>(true);
    }
}