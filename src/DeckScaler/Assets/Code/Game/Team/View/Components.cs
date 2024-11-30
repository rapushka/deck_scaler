using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class SittingInSlot : FlagComponent, IInScope<Game> { }

    public sealed class Appeared : FlagComponent, IInScope<Game> { }
}