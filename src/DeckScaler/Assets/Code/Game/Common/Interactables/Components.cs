using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class EnableOnlyInPlayerPrepare : FlagComponent, IInScope<Game> { }

    public sealed class Interactable : FlagComponent, IInScope<Game>, IEvent<Self> { }
}