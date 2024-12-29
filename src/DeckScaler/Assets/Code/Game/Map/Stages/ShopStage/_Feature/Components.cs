using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class UnitInShopCount : ValueComponent<int>, IInScope<Game> { }

    public sealed class TrinketInShopCount : ValueComponent<int>, IInScope<Game> { }

    public sealed class UnitInShop : FlagComponent, IInScope<Game> { }

    public sealed class TrinketInShop : FlagComponent, IInScope<Game> { }
}