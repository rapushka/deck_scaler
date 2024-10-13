using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class ActionCard : FlagComponent, IInScope { }

    public sealed class Title : ValueComponent<string>, IInScope, IEvent<Self> { }

    public sealed class Description : ValueComponent<string>, IInScope, IEvent<Self> { }

    public sealed class Attack : ValueComponent<AttackConfig>, IInScope { }
}