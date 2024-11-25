using Entitas.Generic;

namespace DeckScaler.Cheats.Component
{
    public sealed class Cheat : ValueComponent<string>, IInScope<Scopes.Cheats> { }

    public sealed class ProcessedCheat : FlagComponent, IInScope<Scopes.Cheats> { }
}