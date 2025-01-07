using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class UpdateShopItemsEvent : FlagComponent, IInScope<Game> { }
}