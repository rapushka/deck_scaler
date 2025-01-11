using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class GameOverAfter : ValueComponent<Timer>, IInScope<Game> { }
}