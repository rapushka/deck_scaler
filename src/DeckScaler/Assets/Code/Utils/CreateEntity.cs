using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public static class CreateEntity
    {
        public static Entity<Model> NewModel()
            => Contexts.Instance.Get<Model>().CreateEntity()
                       .Add<ID, EntityIDBase>(EntityModelIDBase.Next());

        public static Entity<View> NewView()
            => Contexts.Instance.Get<View>().CreateEntity()
                       .Add<ID, EntityIDBase>(EntityViewIDBase.Next());
    }
}