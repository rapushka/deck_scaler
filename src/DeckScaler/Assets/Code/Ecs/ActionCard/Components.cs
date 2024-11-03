using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class ActionCard : FlagComponent, IInScope<Model> { }

    public sealed class Title : ValueComponent<string>, IInScope<View>, IEvent<Self> { }

    public sealed class Description : ValueComponent<string>, IInScope<View>, IEvent<Self> { }

    public sealed class Attack : ValueComponent<AttackConfig>, IInScope<Model> { }
}