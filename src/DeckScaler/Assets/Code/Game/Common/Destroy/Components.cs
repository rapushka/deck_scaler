using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Destroy : FlagComponent, IInScope<Game> { }

    public sealed class DestroyAfterDelay : ValueComponent<Timer>, IInScope<Game> { }
}