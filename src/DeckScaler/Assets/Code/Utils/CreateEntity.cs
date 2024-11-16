using Entitas.Generic;

namespace DeckScaler.Utils
{
    public static class CreateEntity
    {
        public static Entity<TScope> New<TScope>()
            where TScope : IScope
            => Contexts.Instance.Get<TScope>().CreateEntity();
    }
}