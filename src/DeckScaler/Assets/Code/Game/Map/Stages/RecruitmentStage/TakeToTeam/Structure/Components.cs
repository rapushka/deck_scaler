using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TakeToTeam : FlagComponent, IInScope<Game> { }

    public sealed class RecruitSelectedEvent : FlagComponent, IInScope<Game> { }
}