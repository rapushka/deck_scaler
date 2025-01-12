using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class DebugName : ValueComponent<string>, IInScope<Game> { }
}