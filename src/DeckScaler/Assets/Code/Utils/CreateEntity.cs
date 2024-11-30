using DeckScaler.Cheats.Component;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
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

        public static Entity<Scopes.Cheats> Cheat()
            => Contexts.Instance.Get<Scopes.Cheats>().CreateEntity();

        public static Entity<Scopes.Cheats> Cheat(string cheat)
            => Cheat()
                .Add<Cheat, string>(cheat);

        public static Entity<Input> InputOneFrame()
            => Input().Add<Destroy>();

        public static Entity<Input> Input()
            => Contexts.Instance.Get<Input>().CreateEntity();
    }
}