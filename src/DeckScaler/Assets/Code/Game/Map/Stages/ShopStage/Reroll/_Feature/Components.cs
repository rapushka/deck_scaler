using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class RequestReroll : FlagComponent, IInScope<Game> { }

    public sealed class ShopRerollInitialPrice : ValueComponent<int>, IInScope<Game> { }
}