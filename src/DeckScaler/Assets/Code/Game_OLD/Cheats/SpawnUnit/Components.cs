using Entitas.Generic;

namespace DeckScaler.Cheats.Component
{
    public sealed class SpawnUnit : ValueComponent<UnitIDRef>, IInScope<Scopes.Cheats> { }

    public sealed class SpawnUnitAtSide : ValueComponent<Side>, IInScope<Scopes.Cheats> { }
}