using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Destroy : FlagComponent, IInScope<Game>, IInScope<Input> { }

    public sealed class DestroyAfterDelay : ValueComponent<Timer>, IInScope<Game> { }
}