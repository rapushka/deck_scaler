using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class RestockShop : FlagComponent, IInScope<Game> { }

    public sealed class UnitInShopCount : ValueComponent<int>, IInScope<Game> { }

    public sealed class TrinketInShopCount : ValueComponent<int>, IInScope<Game> { }

    public sealed class ShopItem : FlagComponent, IInScope<Game> { }

    public sealed class UnitInShop : FlagComponent, IInScope<Game> { }

    public sealed class TrinketInShop : FlagComponent, IInScope<Game> { }

    public sealed class TryBuy : FlagComponent, IInScope<Game> { }

    public sealed class Bought : FlagComponent, IInScope<Game> { }

    public sealed class PurchaseFailed : FlagComponent, IInScope<Game> { }

    public sealed class NotEnoughMoney : FlagComponent, IInScope<Game> { }

    public sealed class NeedEmptySlot : FlagComponent, IInScope<Game> { }
}