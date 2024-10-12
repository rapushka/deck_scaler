using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Health : ValueComponent<int>, IInScope, IEvent<Self> { }
}