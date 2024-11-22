using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class EndTurn : FlagComponent, IInScope<Game> { }

    public sealed class Attack : ValueComponent<EntityID>, IInScope<Game> { }
}