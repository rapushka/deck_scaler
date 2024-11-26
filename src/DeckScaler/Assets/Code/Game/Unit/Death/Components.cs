using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Dead : FlagComponent, IInScope<Game> { }

    public sealed class JustDied : FlagComponent, IInScope<Game> { }
}