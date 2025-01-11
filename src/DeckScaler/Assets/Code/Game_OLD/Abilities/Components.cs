using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class SendTurnStartedAfter : ValueComponent<Timer>, IInScope<Game> { }

    public sealed class TriggerOnTurnStartedAbility : FlagComponent, IInScope<Game> { }
}