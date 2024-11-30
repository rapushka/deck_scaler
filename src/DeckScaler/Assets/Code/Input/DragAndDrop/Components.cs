using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Draggable : FlagComponent, IInScope<Game> { }

    public sealed class Dragging : FlagComponent, IInScope<Game> { }

    public sealed class Dropped : FlagComponent, IInScope<Game> { }
}