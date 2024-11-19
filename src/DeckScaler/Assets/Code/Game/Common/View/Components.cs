using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class View : ValueComponent<EntityBehaviour>, IInScope<Game> { }

    public sealed class ViewTransform : ValueComponent<Transform>, IInScope<Game> { }
}