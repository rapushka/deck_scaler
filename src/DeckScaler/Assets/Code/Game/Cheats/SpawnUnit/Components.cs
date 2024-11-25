using Entitas.Generic;

namespace DeckScaler.Cheats.Component
{
    public sealed class SpawnTeammate : ValueComponent<UnitIDRef>, IInScope<Scopes.Cheats> { }

    public sealed class SpawnEnemy : ValueComponent<UnitIDRef>, IInScope<Scopes.Cheats> { }
}