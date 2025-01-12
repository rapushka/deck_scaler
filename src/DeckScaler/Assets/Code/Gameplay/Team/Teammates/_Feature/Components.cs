using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Fella : FlagComponent, IInScope<Game> { }

    public sealed class Teammate : FlagComponent, IInScope<Game> { }
}