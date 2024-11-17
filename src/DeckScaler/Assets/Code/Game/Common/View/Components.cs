using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class PrefabToLoad : ValueComponent<EntityBehaviour>, IInScope<Game> { }

    public sealed class View : ValueComponent<EntityBehaviour>, IInScope<Game> { }
}