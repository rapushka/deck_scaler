using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Stats : ValueComponent<StatsData>, IInScope<Model>, IEvent<Self> { }
}