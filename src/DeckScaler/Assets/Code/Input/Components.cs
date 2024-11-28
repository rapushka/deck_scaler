using Entitas.Generic;
using UnityEngine;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Component
{
    public sealed class Cursor : FlagComponent, IInScope<Input> { }

    public sealed class Pressed : FlagComponent, IInScope<Input> { }

    public sealed class MoveDelta : ValueComponent<Vector2>, IInScope<Input> { }

    public sealed class HoveredEntity : ValueComponent<EntityID>, IInScope<Input> { }
}