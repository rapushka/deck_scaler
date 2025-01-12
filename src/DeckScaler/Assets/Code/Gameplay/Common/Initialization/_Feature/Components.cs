using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    /// Entity has this component during first frame after its creation
    public sealed class Initializing : FlagComponent, IInScope<Game> { }

    /// Entity has this component during second frame after its creation
    public sealed class Initialized : FlagComponent, IInScope<Game> { }
}