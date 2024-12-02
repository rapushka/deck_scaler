using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Component
{
    public sealed class WorldPosition : ValueComponent<Vector2>, IInScope<Game>, IInScope<Input> { }

    public sealed class Move : ValueComponent<Vector2>, IInScope<Game> { }
}