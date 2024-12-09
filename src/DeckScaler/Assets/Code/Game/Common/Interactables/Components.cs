using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class EnableOnlyOnPlayerTurn : FlagComponent, IInScope<Game> { }

    public sealed class Interactable : FlagComponent, IInScope<Game>, IEvent<Self> { }
}