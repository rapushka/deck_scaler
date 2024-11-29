using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class View : ValueComponent<EntityBehaviour<Game>>, IInScope<Game> { }

    public sealed class ViewTransform : ValueComponent<Transform>, IInScope<Game> { }
}