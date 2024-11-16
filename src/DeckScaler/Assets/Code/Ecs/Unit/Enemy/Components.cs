using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Enemy : FlagComponent, IInScope<Model> { }

    public sealed class Opponent : ValueComponent<EntityModelIDBase>, IEvent<Self>, IInScope<Model> { }
}