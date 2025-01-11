using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TeamRootScroll : FlagComponent, IInScope<Game> { }

    public sealed class TeamRoot : FlagComponent, IInScope<Game> { }
}