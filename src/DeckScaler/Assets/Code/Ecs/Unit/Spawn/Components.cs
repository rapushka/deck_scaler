using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class SpawnUnit : ValueComponent<(string UnitID, Side Side)>, IInScope<Model> { }

    public sealed class UnitSpawned : ValueComponent<Entity<Model>>, IInScope<Model> { }
}