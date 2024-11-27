using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Cursor : FlagComponent, IInScope<Input> { }

    public sealed class Pressed : FlagComponent, IInScope<Input> { }
}