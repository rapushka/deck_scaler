using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TrinketID : ValueComponent<TrinketIDRef>, IInScope<Game> { }

    public sealed class TrinketAbility : ValueComponent<AffectData>, IInScope<Game> { }
}