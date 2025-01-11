using Entitas.Generic;

namespace DeckScaler.Cheats.Component
{
    public sealed class SpawnUnit : ValueComponent<UnitIDRef>, IInScope<Scopes.Cheats> { } // TODO: REMOVE

    public sealed class SpawnUnitAtSide : ValueComponent<Side>, IInScope<Scopes.Cheats> { }
}