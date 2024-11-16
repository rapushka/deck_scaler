using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class ID : PrimaryIndexComponent<EntityID>, IInScope<Game> { }
}