using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class PlayerInventory : FlagComponent, IInScope<Game> { }

    public sealed class Gold : ValueComponent<int>, IInScope<Game> { }
}