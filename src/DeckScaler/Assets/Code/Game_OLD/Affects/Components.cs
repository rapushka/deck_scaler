using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Affect : FlagComponent, IInScope<Game> { }

    public sealed class AffectID : ValueComponent<AffectType>, IInScope<Game> { }

    public sealed class AffectValue : ValueComponent<int>, IInScope<Game> { }

    public sealed class DealDamageAffect : FlagComponent, IInScope<Game> { }

    public sealed class HealAffect : FlagComponent, IInScope<Game> { }

    public sealed class StealMoneyAffect : FlagComponent, IInScope<Game> { }

    public sealed class SenderID : ValueComponent<EntityID>, IInScope<Game> { }

    public sealed class TargetID : ValueComponent<EntityID>, IInScope<Game> { }
}