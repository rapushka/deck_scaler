using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class MoveSlotToLeft : ValueComponent<int>, IInScope<Game> { }
}