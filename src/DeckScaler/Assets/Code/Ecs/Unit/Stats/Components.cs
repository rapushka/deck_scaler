using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Stats : ValueComponent<DeckScaler.StatsData>, IInScope<Model>, IEvent<Self> { }
}