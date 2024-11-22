using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class BaseDamage : ValueComponent<int>, IInScope<Game> { }
}