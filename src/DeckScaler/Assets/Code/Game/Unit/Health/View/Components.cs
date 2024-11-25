using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class HealthProgressBar : ValueComponent<ProgressBar>, IInScope<Game> { }
}