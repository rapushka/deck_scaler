using Entitas.Generic;

namespace DeckScaler.Cheats.Component
{
    public sealed class Cheat : ValueComponent<string>, IInScope<Scopes.Cheats> { }

    public sealed class Processed : FlagComponent, IInScope<Scopes.Cheats> { }
}