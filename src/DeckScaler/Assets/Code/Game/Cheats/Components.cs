using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Cheat : ValueComponent<string>, IInScope<Cheats> { }

    public sealed class ProcessedCheat : FlagComponent, IInScope<Cheats> { }
}