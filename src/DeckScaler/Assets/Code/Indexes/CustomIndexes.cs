using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public class CustomIndexes
    {
        private readonly Contexts _contexts;

        public CustomIndexes(Contexts contexts)
            => _contexts = contexts;

        public void Initialize()
        {
            new SlotPositionPrimaryIndex(_contexts.Get<Game>()).Initialize();
        }
    }
}