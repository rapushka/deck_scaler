using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class CreateEntity
    {
        public static Entity<Game> Next()
            => Empty().Add<ID, EntityID>(EntityID.Next());

        public static Entity<Game> OneFrame()
            => Empty().Add<Destroy>();

        public static Entity<Game> Empty()
            => Contexts.Instance.Get<Game>().CreateEntity();
    }
}