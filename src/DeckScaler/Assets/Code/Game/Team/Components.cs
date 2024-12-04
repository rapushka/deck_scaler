using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class SlotIndex : ValueComponent<int>, IInScope<Game> { }

    public sealed class SlotPosition : ValueComponent<Vector2>, IInScope<Game> { }
}