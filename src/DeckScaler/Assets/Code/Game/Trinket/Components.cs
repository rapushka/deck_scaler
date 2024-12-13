using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Trinket : ValueComponent<TrinketIDRef>, IInScope<Game> { }

    public sealed class TrinketAbility : ValueComponent<AffectData>, IInScope<Game> { }

    public sealed class Used : FlagComponent, IInScope<Game> { }

    public sealed class SingleUseTrinket : FlagComponent, IInScope<Game> { }
}