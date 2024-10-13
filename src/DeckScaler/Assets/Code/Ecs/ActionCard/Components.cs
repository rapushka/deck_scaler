using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class ActionCard : FlagComponent, IInScope { }

    public sealed class Title : ValueComponent<string>, IInScope { }

    public sealed class Description : ValueComponent<string>, IInScope { }

    public sealed class DealDamage : ValueComponent<float>, IInScope { }

    public sealed class TargetSuit : ValueComponent<Suit>, IInScope { }
}